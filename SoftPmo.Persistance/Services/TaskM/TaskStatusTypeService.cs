using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetAllTaskStatusTypes;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class TaskStatusTypeService : ITaskStatusTypeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TaskStatusTypeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateTaskStatusTypeCommandResponse> CreateAsync(CreateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        TaskStatusType taskStatusType = _mapper.Map<TaskStatusType>(request);

        // Otomatik kod oluştur (TST-001 formatında)
        var lastCode = await _context.Set<TaskStatusType>()
            .Where(tst => tst.Code.StartsWith("TST-"))
            .OrderByDescending(tst => tst.Code)
            .Select(tst => tst.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("TST-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        taskStatusType.Code = $"TST-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<TaskStatusType>().AddAsync(taskStatusType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateTaskStatusTypeCommandResponse(taskStatusType.Id, taskStatusType.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        // Mevcut taskStatusType'ı bul
        TaskStatusType? taskStatusType = await _context.Set<TaskStatusType>()
            .FirstOrDefaultAsync(tst => tst.Id == request.Id, cancellationToken);

        if (taskStatusType is null)
            throw new Exception("İş durumu tipi bulunamadı.");

        // Güncelle
        taskStatusType.Name = request.Name;
        taskStatusType.IsActive = request.IsActive;
        taskStatusType.UpdatedDate = DateTime.UtcNow;

        _context.Set<TaskStatusType>().Update(taskStatusType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        TaskStatusType? taskStatusType = await _context.Set<TaskStatusType>()
            .Include(tst => tst.TaskStatuses)
            .FirstOrDefaultAsync(tst => tst.Id == id, cancellationToken);

        if (taskStatusType is null)
            throw new Exception("İş durumu tipi bulunamadı.");

        // Bu tipe bağlı aktif durumlar var mı kontrol et
        if (taskStatusType.TaskStatuses.Any(ts => ts.IsActive))
            throw new Exception("Bu tipe bağlı aktif iş durumları var. Önce durumları taşıyın.");

        // Soft delete
        taskStatusType.IsActive = false;
        taskStatusType.UpdatedDate = DateTime.UtcNow;

        _context.Set<TaskStatusType>().Update(taskStatusType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<TaskStatusType>> GetAllAsync(GetAllTaskStatusTypesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<TaskStatusType> query = _context.Set<TaskStatusType>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(tst =>
                tst.Name.ToLower().Contains(searchLower) ||
                tst.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(tst => tst.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var taskStatusTypes = await query
            .OrderBy(tst => tst.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return taskStatusTypes;
    }

    public async Task<TaskStatusType> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        TaskStatusType? taskStatusType = await _context.Set<TaskStatusType>()
            .Include(tst => tst.TaskStatuses)
            .FirstOrDefaultAsync(tst => tst.Id == id, cancellationToken);

        if (taskStatusType is null)
            throw new Exception("İş durumu tipi bulunamadı.");

        return taskStatusType;
    }
}