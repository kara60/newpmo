using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.UpdateTask;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetAllTasks;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class TaskService : ITaskService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TaskService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateTaskCommandResponse> CreateAsync(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // Project kontrolü
        var projectExists = await _context.Set<Domain.Entities.Project.ProjectM>()
            .AnyAsync(p => p.Id == request.ProjectId && p.IsActive, cancellationToken);

        if (!projectExists)
            throw new Exception("Proje bulunamadı veya aktif değil.");

        // TaskType kontrolü
        var taskTypeExists = await _context.Set<TaskType>()
            .AnyAsync(tt => tt.Id == request.TaskTypeId && tt.IsActive, cancellationToken);

        if (!taskTypeExists)
            throw new Exception("İş tipi bulunamadı veya aktif değil.");

        // MainResponsibleUser kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.MainResponsibleUserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Sorumlu personel bulunamadı veya aktif değil.");

        // Department kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.DepartmentId))
        {
            var departmentExists = await _context.Set<Department>()
                .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

            if (!departmentExists)
                throw new Exception("Departman bulunamadı veya aktif değil.");
        }

        // TaskStatus kontrolü
        var taskStatusExists = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .AnyAsync(ts => ts.Id == request.TaskStatusId && ts.IsActive, cancellationToken);

        if (!taskStatusExists)
            throw new Exception("İş durumu bulunamadı veya aktif değil.");

        // Priority kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.PriorityId))
        {
            var priorityExists = await _context.Set<Priority>()
                .AnyAsync(p => p.Id == request.PriorityId && p.IsActive, cancellationToken);

            if (!priorityExists)
                throw new Exception("Öncelik bulunamadı veya aktif değil.");
        }

        // Mapping
        Domain.Entities.Task.TaskM task = _mapper.Map<Domain.Entities.Task.TaskM>(request);

        // Otomatik kod oluştur (IS-000001 formatında)
        var lastCode = await _context.Set<Domain.Entities.Task.TaskM>()
            .Where(t => t.Code.StartsWith("IS-"))
            .OrderByDescending(t => t.Code)
            .Select(t => t.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("IS-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        task.Code = $"IS-{nextNumber:D6}";

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Task.TaskM>().AddAsync(task, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTaskCommandResponse(task.Id, task.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        // Mevcut task'ı bul
        Domain.Entities.Task.TaskM? task = await _context.Set<Domain.Entities.Task.TaskM>()
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task is null)
            throw new Exception("İş bulunamadı.");

        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // Project kontrolü
        var projectExists = await _context.Set<Domain.Entities.Project.ProjectM>()
            .AnyAsync(p => p.Id == request.ProjectId && p.IsActive, cancellationToken);

        if (!projectExists)
            throw new Exception("Proje bulunamadı veya aktif değil.");
        // TaskType kontrolü
        var taskTypeExists = await _context.Set<TaskType>()
            .AnyAsync(tt => tt.Id == request.TaskTypeId && tt.IsActive, cancellationToken);

        if (!taskTypeExists)
            throw new Exception("İş tipi bulunamadı veya aktif değil.");

        // MainResponsibleUser kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.MainResponsibleUserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Sorumlu personel bulunamadı veya aktif değil.");

        // Department kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.DepartmentId))
        {
            var departmentExists = await _context.Set<Department>()
                .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

            if (!departmentExists)
                throw new Exception("Departman bulunamadı veya aktif değil.");
        }

        // TaskStatus kontrolü
        var taskStatusExists = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .AnyAsync(ts => ts.Id == request.TaskStatusId && ts.IsActive, cancellationToken);

        if (!taskStatusExists)
            throw new Exception("İş durumu bulunamadı veya aktif değil.");

        // Priority kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.PriorityId))
        {
            var priorityExists = await _context.Set<Priority>()
                .AnyAsync(p => p.Id == request.PriorityId && p.IsActive, cancellationToken);

            if (!priorityExists)
                throw new Exception("Öncelik bulunamadı veya aktif değil.");
        }

        // Güncelle
        task.Title = request.Title;
        task.CustomerId = request.CustomerId;
        task.ProjectId = request.ProjectId;
        task.TaskTypeId = request.TaskTypeId;
        task.MainResponsibleUserId = request.MainResponsibleUserId;
        //task.DepartmentId = request.DepartmentId;
        task.EstimatedDurationDays = request.EstimatedDurationDays;
        task.StartDate = request.StartDate;
        task.DueDate = request.DueDate;
        task.CompletedDate = request.CompletedDate;
        //task = request.BillingMultiplier;
        //task.BillingDuration = request.BillingDuration;
        task.TaskStatusId = request.TaskStatusId;
        task.PriorityId = request.PriorityId;
        task.Description = request.Description;
        task.IsActive = request.IsActive;
        task.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Task.TaskM>().Update(task);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.TaskM? task = await _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.Activities)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (task is null)
            throw new Exception("İş bulunamadı.");

        // Bu işte aktif faaliyetler var mı kontrol et
        if (task.Activities.Any(a => a.IsActive))
            throw new Exception("Bu işte aktif faaliyetler var. Önce faaliyetleri silin.");

        // Soft delete
        task.IsActive = false;
        task.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Task.TaskM>().Update(task);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task ChangeStatusAsync(string id, string taskStatusId, CancellationToken cancellationToken)
    {
        // Task kontrolü
        Domain.Entities.Task.TaskM? task = await _context.Set<Domain.Entities.Task.TaskM>()
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (task is null)
            throw new Exception("İş bulunamadı.");

        // TaskStatus kontrolü
        var taskStatus = await _context.Set<Domain.Entities.Task.TaskStatus>()
            .FirstOrDefaultAsync(ts => ts.Id == taskStatusId && ts.IsActive, cancellationToken);

        if (taskStatus is null)
            throw new Exception("İş durumu bulunamadı veya aktif değil.");

        // Durumu güncelle
        task.TaskStatusId = taskStatusId;
        task.UpdatedDate = DateTime.UtcNow;

        // Eğer durum "Tamamlandı" ise, CompletedDate'i güncelle
        if (taskStatus.TaskStatusType.Name == "Completed")
        {
            task.CompletedDate = DateTime.UtcNow;
        }

        _context.Set<Domain.Entities.Task.TaskM>().Update(task);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> GetAllAsync(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Task.TaskM> query = _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.Customer)
            .Include(t => t.Project)
            .Include(t => t.TaskType)
            .Include(t => t.MainResponsibleUser)
            //.Include(t => t.Department)
            .Include(t => t.TaskStatus)
            .Include(t => t.Priority)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(t =>
                t.Title.ToLower().Contains(searchLower) ||
                t.Code.ToLower().Contains(searchLower) ||
                t.Customer.Name.ToLower().Contains(searchLower) ||
                t.Project.Name.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(t => t.IsActive == request.IsActive.Value);
        }

        // Müşteri filtresi
        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            query = query.Where(t => t.CustomerId == request.CustomerId);
        }

        // Proje filtresi
        if (!string.IsNullOrEmpty(request.ProjectId))
        {
            query = query.Where(t => t.ProjectId == request.ProjectId);
        }

        // Sorumlu personel filtresi
        if (!string.IsNullOrEmpty(request.MainResponsibleUserId))
        {
            query = query.Where(t => t.MainResponsibleUserId == request.MainResponsibleUserId);
        }

        // İş durumu filtresi
        if (!string.IsNullOrEmpty(request.TaskStatusId))
        {
            query = query.Where(t => t.TaskStatusId == request.TaskStatusId);
        }

        // Öncelik filtresi
        if (!string.IsNullOrEmpty(request.PriorityId))
        {
            query = query.Where(t => t.PriorityId == request.PriorityId);
        }

        // Sayfalama
        var tasks = await query
            .OrderByDescending(t => t.CreatedDate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return tasks;
    }

    public async Task<Domain.Entities.Task.TaskM> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.TaskM? task = await _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.Customer)
            .Include(t => t.Project)
            .Include(t => t.TaskType)
            .Include(t => t.MainResponsibleUser)
            //.Include(t => t.Department)
            .Include(t => t.TaskStatus)
            .Include(t => t.Priority)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (task is null)
            throw new Exception("İş bulunamadı.");

        return task;
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> GetByProjectAsync(string projectId, CancellationToken cancellationToken)
    {
        var tasks = await _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.TaskType)
            .Include(t => t.MainResponsibleUser)
            .Include(t => t.TaskStatus)
            .Include(t => t.Priority)
            .Where(t => t.ProjectId == projectId && t.IsActive)
            .OrderByDescending(t => t.CreatedDate)
            .ToListAsync(cancellationToken);

        return tasks;
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> GetByUserAsync(string userId, CancellationToken cancellationToken)
    {
        var tasks = await _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.Customer)
            .Include(t => t.Project)
            .Include(t => t.TaskType)
            .Include(t => t.TaskStatus)
            .Include(t => t.Priority)
            .Where(t => t.MainResponsibleUserId == userId && t.IsActive)
            .OrderBy(t => t.DueDate)
            .ToListAsync(cancellationToken);

        return tasks;
    }

    public async Task<Domain.Entities.Task.TaskM> GetWithDetailsAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Task.TaskM? task = await _context.Set<Domain.Entities.Task.TaskM>()
            .Include(t => t.Customer)
            .Include(t => t.Project)
                .ThenInclude(p => p.ProjectManager)
            .Include(t => t.TaskType)
            .Include(t => t.MainResponsibleUser)
                .ThenInclude(u => u.Department)
            .Include(t => t.MainResponsibleUser)
                .ThenInclude(u => u.Position)
            .Include(t => t.TaskStatus)
            .Include(t => t.Priority)
            .Include(t => t.Activities.Where(a => a.IsActive))
                .ThenInclude(a => a.User)
            .Include(t => t.Activities.Where(a => a.IsActive))
                .ThenInclude(a => a.Location)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

        if (task is null)
            throw new Exception("İş bulunamadı.");

        return task;
    }
}