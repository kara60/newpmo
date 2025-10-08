using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetAllTaskTypes;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class TaskTypeService : ITaskTypeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TaskTypeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateTaskTypeCommandResponse> CreateAsync(CreateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        TaskType taskType = _mapper.Map<TaskType>(request);

        // Otomatik kod oluştur (TASK-TYPE-001 formatında)
        var lastCode = await _context.Set<TaskType>()
            .Where(tt => tt.Code.StartsWith("TASK-TYPE-"))
            .OrderByDescending(tt => tt.Code)
            .Select(tt => tt.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("TASK-TYPE-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        taskType.Code = $"TASK-TYPE-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<TaskType>().AddAsync(taskType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTaskTypeCommandResponse(taskType.Id, taskType.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        // Mevcut taskType'ı bul
        TaskType? taskType = await _context.Set<TaskType>()
            .FirstOrDefaultAsync(tt => tt.Id == request.Id, cancellationToken);

        if (taskType is null)
            throw new Exception("İş tipi bulunamadı.");

        // Güncelle
        taskType.Name = request.Name;
        taskType.Category = request.Category;
        taskType.ColorCode = request.ColorCode;
        taskType.Icon = request.IconCode;
        taskType.IsActive = request.IsActive;
        taskType.UpdatedDate = DateTime.UtcNow;

        _context.Set<TaskType>().Update(taskType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        TaskType? taskType = await _context.Set<TaskType>()
            .Include(tt => tt.Tasks)
            .Include(tt => tt.TaskTypeSteps)
            .FirstOrDefaultAsync(tt => tt.Id == id, cancellationToken);

        if (taskType is null)
            throw new Exception("İş tipi bulunamadı.");

        // Bu tipte aktif işler var mı kontrol et
        if (taskType.Tasks.Any(t => t.IsActive))
            throw new Exception("Bu tipte aktif işler var. Önce işleri taşıyın.");

        // Soft delete
        taskType.IsActive = false;
        taskType.UpdatedDate = DateTime.UtcNow;

        _context.Set<TaskType>().Update(taskType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<TaskType>> GetAllAsync(GetAllTaskTypesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TaskType> query = _context.Set<TaskType>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(tt =>
                tt.Name.ToLower().Contains(searchLower) ||
                tt.Code.ToLower().Contains(searchLower) ||
                (tt.Category != null && tt.Category.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(tt => tt.IsActive == request.IsActive.Value);
        }

        // Kategori filtresi
        if (!string.IsNullOrEmpty(request.Category))
        {
            query = query.Where(tt => tt.Category == request.Category);
        }

        // Sayfalama
        var taskTypes = await query
            .OrderBy(tt => tt.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return taskTypes;
    }

    public async Task<TaskType> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        TaskType? taskType = await _context.Set<TaskType>()
            .Include(tt => tt.TaskTypeSteps)
            .FirstOrDefaultAsync(tt => tt.Id == id, cancellationToken);

        if (taskType is null)
            throw new Exception("İş tipi bulunamadı.");

        return taskType;
    }
}