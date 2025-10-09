using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetAllActivities;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ActivityM;

public sealed class ActivityService : IActivityService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ActivityService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateActivityCommandResponse> CreateAsync(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        // User kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.UserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Personel bulunamadı veya aktif değil.");

        // Task kontrolü
        var taskExists = await _context.Set<Domain.Entities.Task.TaskM>()
            .AnyAsync(t => t.Id == request.TaskId && t.IsActive, cancellationToken);

        if (!taskExists)
            throw new Exception("İş bulunamadı veya aktif değil.");

        // Location kontrolü
        var locationExists = await _context.Set<Location>()
            .AnyAsync(l => l.Id == request.LocationId && l.IsActive, cancellationToken);

        if (!locationExists)
            throw new Exception("Lokasyon bulunamadı veya aktif değil.");

        // CustomerLocation kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.CustomerLocationId))
        {
            var customerLocationExists = await _context.Set<CustomerLocation>()
                .AnyAsync(cl => cl.Id == request.CustomerLocationId && cl.IsActive, cancellationToken);

            if (!customerLocationExists)
                throw new Exception("Müşteri lokasyonu bulunamadı veya aktif değil.");
        }

        // Mapping
        Domain.Entities.Activity.ActivityM activity = _mapper.Map<Domain.Entities.Activity.ActivityM>(request);

        // Otomatik kod oluştur (ACT-000001 formatında)
        var lastCode = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .Where(a => a.Code.StartsWith("ACT-"))
            .OrderByDescending(a => a.Code)
            .Select(a => a.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("ACT-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        activity.Code = $"ACT-{nextNumber:D6}";

        // Varsayılan onay durumu
        //activity./*IsApproved*/ = false;

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Activity.ActivityM>().AddAsync(activity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateActivityCommandResponse(activity.Id, activity.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        // Mevcut activity'yi bul
        Domain.Entities.Activity.ActivityM? activity = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

        if (activity is null)
            throw new Exception("Faaliyet bulunamadı.");

        // Onaylanmış faaliyet güncellenemez
        if (activity.ApprovalDate != DateTime.MinValue)
            throw new Exception("Onaylanmış faaliyet güncellenemez.");

        // User kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.UserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Personel bulunamadı veya aktif değil.");

        // Task kontrolü
        var taskExists = await _context.Set<Domain.Entities.Task.TaskM>()
            .AnyAsync(t => t.Id == request.TaskId && t.IsActive, cancellationToken);

        if (!taskExists)
            throw new Exception("İş bulunamadı veya aktif değil.");

        // Location kontrolü
        var locationExists = await _context.Set<Location>()
            .AnyAsync(l => l.Id == request.LocationId && l.IsActive, cancellationToken);

        if (!locationExists)
            throw new Exception("Lokasyon bulunamadı veya aktif değil.");

        // CustomerLocation kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.CustomerLocationId))
        {
            var customerLocationExists = await _context.Set<CustomerLocation>()
                .AnyAsync(cl => cl.Id == request.CustomerLocationId && cl.IsActive, cancellationToken);

            if (!customerLocationExists)
                throw new Exception("Müşteri lokasyonu bulunamadı veya aktif değil.");
        }

        // Güncelle
        activity.UserId = request.UserId;
        activity.TaskId = request.TaskId;
        activity.StartTime = request.StartTime;
        activity.EndTime = request.EndTime;
        activity.DurationMinutes = request.DurationMinutes;
        activity.LocationId = request.LocationId;
        activity.CustomerLocationId = request.CustomerLocationId;
        activity.IsActive = request.IsActive;
        activity.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Activity.ActivityM>().Update(activity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Activity.ActivityM? activity = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (activity is null)
            throw new Exception("Faaliyet bulunamadı.");

        // Onaylanmış faaliyet silinemez
        //if (activity.IsApproved)
        //    throw new Exception("Onaylanmış faaliyet silinemez.");

        // Soft delete
        activity.IsActive = false;
        activity.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Activity.ActivityM>().Update(activity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task ApproveAsync(string id, string approvedByUserId, bool isApproved, string? approvalNote, CancellationToken cancellationToken)
    {
        // Activity kontrolü
        Domain.Entities.Activity.ActivityM? activity = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (activity is null)
            throw new Exception("Faaliyet bulunamadı.");

        // Approver kontrolü
        var approverExists = await _context.Set<User>().AnyAsync(u => u.Id == approvedByUserId && u.IsActive, cancellationToken);
        if (!approverExists)
            throw new Exception("Onaylayan personel bulunamadı veya aktif değil.");

        // Onay bilgilerini güncelle
        //activity.IsApproved = isApproved;
        activity.ApprovedByUserId = approvedByUserId;
        activity.ApprovalDate = DateTime.UtcNow;
        activity.ApprovalNote = approvalNote;
        activity.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Activity.ActivityM>().Update(activity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> GetAllAsync(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Activity.ActivityM> query = _context.Set<Domain.Entities.Activity.ActivityM>()
            .Include(a => a.User)
            .Include(a => a.Task)
                .ThenInclude(t => t.Customer)
            .Include(a => a.Task)
                .ThenInclude(t => t.Project)
            .Include(a => a.Location)
            .Include(a => a.CustomerLocation)
            .Include(a => a.ApprovedByUser)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(a =>
                a.Code.ToLower().Contains(searchLower) ||
                a.User.FirstName.ToLower().Contains(searchLower) ||
                a.User.LastName.ToLower().Contains(searchLower) ||
                a.Task.Title.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(a => a.IsActive == request.IsActive.Value);
        }

        // Onay durumu filtresi
        //if (request.IsApproved.HasValue)
        //{
        //    query = query.Where(a => a.IsApproved == request.IsApproved.Value);
        //}

        // Personel filtresi
        if (!string.IsNullOrEmpty(request.UserId))
        {
            query = query.Where(a => a.UserId == request.UserId);
        }

        // İş filtresi
        if (!string.IsNullOrEmpty(request.TaskId))
        {
            query = query.Where(a => a.TaskId == request.TaskId);
        }

        // Tarih aralığı filtresi
        if (request.StartDate.HasValue)
        {
            query = query.Where(a => a.StartTime >= request.StartDate.Value.Date);
        }

        if (request.EndDate.HasValue)
        {
            query = query.Where(a => a.EndTime <= request.EndDate.Value.Date);
        }

        // Sayfalama
        var activities = await query
            .OrderByDescending(a => a.StartTime)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return activities;
    }

    public async Task<Domain.Entities.Activity.ActivityM> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Activity.ActivityM? activity = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .Include(a => a.User)
            .Include(a => a.Task)
                .ThenInclude(t => t.Customer)
            .Include(a => a.Task)
                .ThenInclude(t => t.Project)
            .Include(a => a.Location)
            .Include(a => a.CustomerLocation)
            .Include(a => a.ApprovedByUser)
            .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

        if (activity is null)
            throw new Exception("Faaliyet bulunamadı.");

        return activity;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> GetByUserAsync(string userId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Activity.ActivityM> query = _context.Set<Domain.Entities.Activity.ActivityM>()
            .Include(a => a.Task)
                .ThenInclude(t => t.Customer)
            .Include(a => a.Task)
                .ThenInclude(t => t.Project)
            .Include(a => a.Location)
            .Include(a => a.CustomerLocation)
            .Where(a => a.UserId == userId && a.IsActive);

        // Tarih aralığı filtresi
        if (startDate.HasValue)
        {
            query = query.Where(a => a.StartTime >= startDate.Value.Date);
        }

        if (endDate.HasValue)
        {
            query = query.Where(a => a.EndTime <= endDate.Value.Date);
        }

        var activities = await query
            .OrderByDescending(a => a.StartTime)
            .ToListAsync(cancellationToken);

        return activities;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> GetByTaskAsync(string taskId, CancellationToken cancellationToken)
    {
        var activities = await _context.Set<Domain.Entities.Activity.ActivityM>()
            .Include(a => a.User)
            .Include(a => a.Location)
            .Include(a => a.CustomerLocation)
            .Where(a => a.TaskId == taskId && a.IsActive)
            .OrderByDescending(a => a.StartTime)
            .ToListAsync(cancellationToken);

        return activities;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> GetPendingApprovalsAsync(string? managerId, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Activity.ActivityM> query = _context.Set<Domain.Entities.Activity.ActivityM>()
            .Include(a => a.User)
                .ThenInclude(u => u.DirectManager)
            .Include(a => a.Task)
                .ThenInclude(t => t.Customer)
            .Include(a => a.Task)
                .ThenInclude(t => t.Project)
            .Include(a => a.Location);

        // Eğer managerId verilmişse, sadece o yöneticinin ekibinin faaliyetlerini getir
        if (!string.IsNullOrEmpty(managerId))
        {
            query = query.Where(a => a.User.DirectManagerId == managerId);
        }

        var activities = await query
            .OrderBy(a => a.StartTime)
            .ToListAsync(cancellationToken);

        return activities;
    }
}