using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetAllLocationTypes;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.SystemBase;

public sealed class LocationTypeService : ILocationTypeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public LocationTypeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateLocationTypeCommandResponse> CreateAsync(CreateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        LocationType locationType = _mapper.Map<LocationType>(request);

        // Otomatik kod oluştur (LOC-TYPE-001 formatında)
        var lastCode = await _context.Set<LocationType>()
            .Where(lt => lt.Code.StartsWith("LOC-TYPE-"))
            .OrderByDescending(lt => lt.Code)
            .Select(lt => lt.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("LOC-TYPE-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        locationType.Code = $"LOC-TYPE-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<LocationType>().AddAsync(locationType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateLocationTypeCommandResponse(locationType.Id, locationType.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        // Mevcut locationType'ı bul
        LocationType? locationType = await _context.Set<LocationType>()
            .FirstOrDefaultAsync(lt => lt.Id == request.Id, cancellationToken);

        if (locationType is null)
            throw new Exception("Lokasyon tipi bulunamadı.");

        // Güncelle
        locationType.Name = request.Name;
        locationType.IsActive = request.IsActive;
        locationType.UpdatedDate = DateTime.UtcNow;

        _context.Set<LocationType>().Update(locationType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        LocationType? locationType = await _context.Set<LocationType>()
            .Include(lt => lt.Locations)
            .FirstOrDefaultAsync(lt => lt.Id == id, cancellationToken);

        if (locationType is null)
            throw new Exception("Lokasyon tipi bulunamadı.");

        // Bu tipe bağlı lokasyonlar var mı kontrol et
        if (locationType.Locations.Any(l => l.IsActive))
            throw new Exception("Bu tipe bağlı aktif lokasyonlar var. Önce lokasyonları taşıyın.");

        // Soft delete
        locationType.IsActive = false;
        locationType.UpdatedDate = DateTime.UtcNow;

        _context.Set<LocationType>().Update(locationType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<LocationType>> GetAllAsync(GetAllLocationTypesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<LocationType> query = _context.Set<LocationType>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(lt =>
                lt.Name.ToLower().Contains(searchLower) ||
                lt.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(lt => lt.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var locationTypes = await query
            .OrderBy(lt => lt.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return locationTypes;
    }

    public async Task<LocationType> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        LocationType? locationType = await _context.Set<LocationType>()
            .Include(lt => lt.Locations)
            .FirstOrDefaultAsync(lt => lt.Id == id, cancellationToken);

        if (locationType is null)
            throw new Exception("Lokasyon tipi bulunamadı.");

        return locationType;
    }
}