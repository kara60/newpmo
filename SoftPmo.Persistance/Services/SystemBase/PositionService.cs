using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.SystemBase;

public sealed class PositionService : IPositionService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PositionService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreatePositionCommandResponse> CreateAsync(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        // Departman kontrolü
        var departmentExists = await _context.Set<Department>()
            .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

        if (!departmentExists)
            throw new Exception("Departman bulunamadı veya aktif değil.");

        // PositionLevel kontrolü
        var levelExists = await _context.Set<PositionLevel>()
            .AnyAsync(pl => pl.Id == request.PositionLevelId && pl.IsActive, cancellationToken);

        if (!levelExists)
            throw new Exception("Pozisyon seviyesi bulunamadı veya aktif değil.");

        // Mapping
        Position position = _mapper.Map<Position>(request);

        // Otomatik kod oluştur (POS-001 formatında)
        var lastCode = await _context.Set<Position>()
            .Where(p => p.Code.StartsWith("POS-"))
            .OrderByDescending(p => p.Code)
            .Select(p => p.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("POS-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        position.Code = $"POS-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Position>().AddAsync(position, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreatePositionCommandResponse(position.Id, position.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        // Mevcut position'ı bul
        Position? position = await _context.Set<Position>()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (position is null)
            throw new Exception("Pozisyon bulunamadı.");

        // Departman kontrolü
        var departmentExists = await _context.Set<Department>()
            .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

        if (!departmentExists)
            throw new Exception("Departman bulunamadı veya aktif değil.");

        // PositionLevel kontrolü
        var levelExists = await _context.Set<PositionLevel>()
            .AnyAsync(pl => pl.Id == request.PositionLevelId && pl.IsActive, cancellationToken);

        if (!levelExists)
            throw new Exception("Pozisyon seviyesi bulunamadı veya aktif değil.");

        // Güncelle
        position.Name = request.Name;
        position.DepartmentId = request.DepartmentId;
        position.PositionLevelId = request.PositionLevelId;
        position.BillingMultiplier = request.BillingMultiplier;
        position.IsActive = request.IsActive;
        position.UpdatedDate = DateTime.UtcNow;

        _context.Set<Position>().Update(position);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Position? position = await _context.Set<Position>()
            .Include(p => p.Users)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (position is null)
            throw new Exception("Pozisyon bulunamadı.");

        // Bu pozisyonda çalışan var mı kontrol et
        if (position.Users.Any(u => u.IsActive))
            throw new Exception("Bu pozisyonda aktif çalışanlar var. Önce çalışanları taşıyın.");

        // Soft delete
        position.IsActive = false;
        position.UpdatedDate = DateTime.UtcNow;

        _context.Set<Position>().Update(position);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Position>> GetAllAsync(GetAllPositionsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Position> query = _context.Set<Position>()
            .Include(p => p.Department)
            .Include(p => p.PositionLevel)
            .Where(p => p.IsActive) // Sadece aktif pozisyonlar
            .OrderBy(p => p.CreatedDate)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(searchLower) ||
                p.Code.ToLower().Contains(searchLower) ||
                p.Department.Name.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // Departman filtresi
        if (!string.IsNullOrEmpty(request.DepartmentId))
        {
            query = query.Where(p => p.DepartmentId == request.DepartmentId);
        }

        // PositionLevel filtresi
        if (!string.IsNullOrEmpty(request.PositionLevelId))
        {
            query = query.Where(p => p.PositionLevelId == request.PositionLevelId);
        }

        // Sayfalama
        var positions = await query
            .OrderBy(p => p.Department.Name)
            .ThenBy(p => p.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return positions;
    }

    public async Task<Position> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Position? position = await _context.Set<Position>()
            .Include(p => p.Department)
            .Include(p => p.PositionLevel)
            .Include(p => p.Users)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (position is null)
            throw new Exception("Pozisyon bulunamadı.");

        return position;
    }

    public async Task<IList<Position>> GetByDepartmentAsync(string departmentId, CancellationToken cancellationToken)
    {
        var positions = await _context.Set<Position>()
            .Include(p => p.PositionLevel)
            .Where(p => p.DepartmentId == departmentId && p.IsActive)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        return positions;
    }
}