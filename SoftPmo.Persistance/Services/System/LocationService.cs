using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Application.Features.LocationFeatures.Queries.GetAllLocations;
using SoftPmo.Application.Services.System;
using SoftPmo.Domain.Entities.System;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.System;

public sealed class LocationService : ILocationService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICodeTemplateService _codeTemplateService;

    public LocationService(AppDbContext context, IMapper mapper, ICodeTemplateService codeTemplateService)
    {
        _context = context;
        _mapper = mapper;
        _codeTemplateService = codeTemplateService;
    }

    public async Task<CreateLocationCommandResponse> CreateAsync(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        // Location entity'yi map et
        Location location = _mapper.Map<Location>(request);

        // Otomatik kod oluştur (LOK-001 formatında)
        var codeTemplates = await _context.Set<CodeTemplate>()
            .Where(ct => ct.EntityType == "Location" && ct.IsActive)
            .ToListAsync(cancellationToken);

        if (codeTemplates.Any())
        {
            var template = codeTemplates.First();
            location.Code = await GenerateCode(template);

            // Template'in CurrentSequence'ini artır
            template.CurrentNumber++;
            _context.Set<CodeTemplate>().Update(template);
        }
        else
        {
            // Eğer template yoksa basit bir kod üret
            var lastCode = await _context.Set<Location>()
                .Where(l => l.Code.StartsWith("LOK-"))
                .OrderByDescending(l => l.Code)
                .Select(l => l.Code)
                .FirstOrDefaultAsync(cancellationToken);

            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastCode))
            {
                var numberPart = lastCode.Replace("LOK-", "");
                if (int.TryParse(numberPart, out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }
            location.Code = $"LOK-{nextNumber:D3}";
        }

        // Veritabanına ekle
        await _context.Set<Location>().AddAsync(location, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateLocationCommandResponse(location.Id, location.Code);
    }

    public async Task UpdateAsync(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        // Mevcut location'ı bul
        Location? location = await _context.Set<Location>()
            .FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);

        if (location is null)
            throw new Exception("Lokasyon bulunamadı.");

        // Güncelle
        location.Name = request.Name;
        location.LocationTypeId = request.LocationTypeId;
        location.Address = request.Address;
        location.Phone = request.Phone;
        location.IsActive = request.IsActive;
        location.UpdatedDate = DateTime.UtcNow;

        _context.Set<Location>().Update(location);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Location? location = await _context.Set<Location>()
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        if (location is null)
            throw new Exception("Lokasyon bulunamadı.");

        // Soft delete
        location.IsActive = false;
        location.UpdatedDate = DateTime.UtcNow;

        _context.Set<Location>().Update(location);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Location>> GetAllAsync(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Location> query = _context.Set<Location>()
            .Include(l => l.LocationType)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(l =>
                l.Name.ToLower().Contains(searchLower) ||
                l.Code.ToLower().Contains(searchLower) ||
                (l.Address != null && l.Address.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(l => l.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var locations = await query
            .OrderBy(l => l.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return locations;
    }

    public async Task<Location> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Location? location = await _context.Set<Location>()
            .Include(l => l.LocationType)
            .FirstOrDefaultAsync(l => l.Id == id, cancellationToken);

        if (location is null)
            throw new Exception("Lokasyon bulunamadı.");

        return location;
    }

    // Kod üretme helper metodu
    private async Task<string> GenerateCode(CodeTemplate template)
    {
        string code = template.CodeFormat;

        // Prefix ekle
        code = code.Replace("{PREFIX}", template.Prefix);

        // Yıl ekle (eğer kullanılıyorsa)
        if (template.UseYear)
        {
            code = code.Replace("{YYYY}", DateTime.Now.Year.ToString());
            code = code.Replace("{YY}", DateTime.Now.Year.ToString().Substring(2));
        }

        // Sıra numarasını ekle
        string sequenceFormat = new string('0', template.SequenceLength);
        string sequence = template.CurrentNumber.ToString(sequenceFormat);
        code = code.Replace("{SEQ}", sequence);

        return code;
    }
}