using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetAllPositionLevels;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.SystemBase;

public sealed class PositionLevelService : IPositionLevelService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PositionLevelService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreatePositionLevelCommandResponse> CreateAsync(CreatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        PositionLevel positionLevel = _mapper.Map<PositionLevel>(request);

        // Otomatik kod oluştur (POS-LVL-001 formatında)
        var lastCode = await _context.Set<PositionLevel>()
            .Where(pl => pl.Code.StartsWith("POS-LVL-"))
            .OrderByDescending(pl => pl.Code)
            .Select(pl => pl.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("POS-LVL-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        positionLevel.Code = $"POS-LVL-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<PositionLevel>().AddAsync(positionLevel, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreatePositionLevelCommandResponse(positionLevel.Id, positionLevel.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        // Mevcut positionLevel'ı bul
        PositionLevel? positionLevel = await _context.Set<PositionLevel>()
            .FirstOrDefaultAsync(pl => pl.Id == request.Id, cancellationToken);

        if (positionLevel is null)
            throw new Exception("Pozisyon seviyesi bulunamadı.");

        // Güncelle
        positionLevel.Name = request.Name;
        positionLevel.DefaultBillingMultiplier = request.DefaultBillingMultiplier;
        positionLevel.SortOrder = request.SortOrder;
        positionLevel.ColorCode = request.ColorCode;
        positionLevel.IsActive = request.IsActive;
        positionLevel.UpdatedDate = DateTime.UtcNow;

        _context.Set<PositionLevel>().Update(positionLevel);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        PositionLevel? positionLevel = await _context.Set<PositionLevel>()
            .Include(pl => pl.Positions)
            .FirstOrDefaultAsync(pl => pl.Id == id, cancellationToken);

        if (positionLevel is null)
            throw new Exception("Pozisyon seviyesi bulunamadı.");

        // Bu seviyede pozisyonlar var mı kontrol et
        if (positionLevel.Positions.Any(p => p.IsActive))
            throw new Exception("Bu seviyede aktif pozisyonlar var. Önce pozisyonları taşıyın.");

        // Soft delete
        positionLevel.IsActive = false;
        positionLevel.UpdatedDate = DateTime.UtcNow;

        _context.Set<PositionLevel>().Update(positionLevel);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<PositionLevel>> GetAllAsync(GetAllPositionLevelsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<PositionLevel> query = _context.Set<PositionLevel>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(pl =>
                pl.Name.ToLower().Contains(searchLower) ||
                pl.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(pl => pl.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var positionLevels = await query
            .OrderBy(pl => pl.SortOrder)
            .ThenBy(pl => pl.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return positionLevels;
    }

    public async Task<PositionLevel> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        PositionLevel? positionLevel = await _context.Set<PositionLevel>()
            .Include(pl => pl.Positions)
            .FirstOrDefaultAsync(pl => pl.Id == id, cancellationToken);

        if (positionLevel is null)
            throw new Exception("Pozisyon seviyesi bulunamadı.");

        return positionLevel;
    }
}