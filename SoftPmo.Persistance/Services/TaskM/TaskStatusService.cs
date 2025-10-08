using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetAllTaskStatuses;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class TaskStatusService : ITaskStatusService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TaskStatusService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateTaskStatusCommandResponse> CreateAsync(CreateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        // TaskStatusType kontrolü
        var typeExists = await _context.Set<TaskStatusType>()
            .AnyAsync(tst => tst.Id == request.TaskStatusTypeId && tst.IsActive, cancellationToken);

        if (!typeExists)
            throw new Exception("İş durumu tipi bulunamadı veya aktif değil.");

        // Mapping
        Domain.Entities.Task.TaskStatus taskStatus = _mapper.Map<Domain.Entities.Task.TaskStatus>(request);

        // Otomatik kod oluştur (TASK-ST-001 formatında)
        var lastCode = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .Where(ts => ts.Code.StartsWith("TASK-ST-"))
            .OrderByDescending(ts => ts.Code)
            .Select(ts => ts.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("TASK-ST-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        taskStatus.Code = $"TASK-ST-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Task.TaskStatus>().AddAsync(taskStatus, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTaskStatusCommandResponse(taskStatus.Id, taskStatus.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        // Mevcut taskStatus'u bul
        Domain.Entities.Task.TaskStatus? taskStatus = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .FirstOrDefaultAsync(ts => ts.Id == request.Id, cancellationToken);

        if (taskStatus is null)
            throw new Exception("İş durumu bulunamadı.");

        // TaskStatusType kontrolü
        var typeExists = await _context.Set<TaskStatusType>()
            .AnyAsync(tst => tst.Id == request.TaskStatusTypeId && tst.IsActive, cancellationToken);

        if (!typeExists)
            throw new Exception("İş durumu tipi bulunamadı veya aktif değil.");

        // Güncelle
        taskStatus.Name = request.Name;
        taskStatus.TaskStatusTypeId = request.TaskStatusTypeId;
        taskStatus.SortOrder = request.SortOrder;
        taskStatus.ColorCode = request.ColorCode;
        taskStatus.IsActive = request.IsActive;
        taskStatus.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Task.TaskStatus>().Update(taskStatus);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.TaskStatus? taskStatus = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .Include(ts => ts.Tasks)
            .Include(ts => ts.TaskSteps)
            .FirstOrDefaultAsync(ts => ts.Id == id, cancellationToken);

        if (taskStatus is null)
            throw new Exception("İş durumu bulunamadı.");

        // Bu durumda aktif işler veya adımlar var mı kontrol et
        bool hasActiveTasks = taskStatus.Tasks.Any(t => t.IsActive);
        bool hasActiveSteps = taskStatus.TaskSteps.Any(ts => ts.IsActive);

        if (hasActiveTasks || hasActiveSteps)
            throw new Exception("Bu durumda aktif işler veya adımlar var. Önce bunları taşıyın.");

        // Soft delete
        taskStatus.IsActive = false;
        taskStatus.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Task.TaskStatus>().Update(taskStatus);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Task.TaskStatus>> GetAllAsync(GetAllTaskStatusesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Task.TaskStatus> query = _context.Set<Domain.Entities.Task.TaskStatus>()
            .Include(ts => ts.TaskStatusType)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(ts =>
                ts.Name.ToLower().Contains(searchLower) ||
                ts.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(ts => ts.IsActive == request.IsActive.Value);
        }

        // TaskStatusType filtresi
        if (!string.IsNullOrEmpty(request.TaskStatusTypeId))
        {
            query = query.Where(ts => ts.TaskStatusTypeId == request.TaskStatusTypeId);
        }

        // Sayfalama
        var taskStatuses = await query
            .OrderBy(ts => ts.SortOrder)
            .ThenBy(ts => ts.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return taskStatuses;
    }

    public async Task<Domain.Entities.Task.TaskStatus> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.TaskStatus? taskStatus = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .Include(ts => ts.TaskStatusType)
            .FirstOrDefaultAsync(ts => ts.Id == id, cancellationToken);

        if (taskStatus is null)
            throw new Exception("İş durumu bulunamadı.");

        return taskStatus;
    }

    public async Task<IList<Domain.Entities.Task.TaskStatus>> GetByTypeAsync(string taskStatusTypeId, CancellationToken cancellationToken)
    {
        var taskStatuses = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .Include(ts => ts.TaskStatusType)
            .Where(ts => ts.TaskStatusTypeId == taskStatusTypeId && ts.IsActive)
            .OrderBy(ts => ts.SortOrder)
            .ThenBy(ts => ts.Name)
            .ToListAsync(cancellationToken);

        return taskStatuses;
    }
}