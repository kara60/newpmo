using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetAllPriorities;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class PriorityService : IPriorityService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public PriorityService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreatePriorityCommandResponse> CreateAsync(CreatePriorityCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        Priority priority = _mapper.Map<Priority>(request);

        // Otomatik kod oluştur (PRI-001 formatında)
        var lastCode = await _context.Set<Priority>()
            .Where(p => p.Code.StartsWith("PRI-"))
            .OrderByDescending(p => p.Code)
            .Select(p => p.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRI-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        priority.Code = $"PRI-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Priority>().AddAsync(priority, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreatePriorityCommandResponse(priority.Id, priority.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdatePriorityCommand request, CancellationToken cancellationToken)
    {
        // Mevcut priority'yi bul
        Priority? priority = await _context.Set<Priority>()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (priority is null)
            throw new Exception("Öncelik bulunamadı.");

        // Güncelle
        priority.Name = request.Name;
        priority.SortOrder = request.SortOrder;
        priority.ColorCode = request.ColorCode;
        priority.Icon = request.IconCode;
        priority.IsActive = request.IsActive;
        priority.UpdatedDate = DateTime.UtcNow;

        _context.Set<Priority>().Update(priority);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Priority? priority = await _context.Set<Priority>()
            .Include(p => p.Tasks)
            .Include(p => p.TodoItems)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (priority is null)
            throw new Exception("Öncelik bulunamadı.");

        // Bu öncelikte işler veya todo'lar var mı kontrol et
        bool hasActiveTasks = priority.Tasks.Any(t => t.IsActive);
        bool hasActiveTodos = priority.TodoItems.Any(t => t.IsActive);

        if (hasActiveTasks || hasActiveTodos)
            throw new Exception("Bu öncelikte aktif işler veya todo'lar var. Önce bunları taşıyın.");

        // Soft delete
        priority.IsActive = false;
        priority.UpdatedDate = DateTime.UtcNow;

        _context.Set<Priority>().Update(priority);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Priority>> GetAllAsync(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Priority> query = _context.Set<Priority>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(searchLower) ||
                p.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var priorities = await query
            .OrderBy(p => p.SortOrder)
            .ThenBy(p => p.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return priorities;
    }

    public async Task<Priority> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Priority? priority = await _context.Set<Priority>()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (priority is null)
            throw new Exception("Öncelik bulunamadı.");

        return priority;
    }
}