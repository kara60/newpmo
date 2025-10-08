using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetAllNotifications;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Notification;
using SoftPmo.Persistance.Context;
using System.Xml.Linq;

namespace SoftPmo.Persistance.Services.NotificationM;

public sealed class NotificationService : INotificationService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public NotificationService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateNotificationCommandResponse> CreateAsync(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        // User kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.UserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Kullanıcı bulunamadı veya aktif değil.");

        // Mapping
        Domain.Entities.Notification.NotificationM notification = _mapper.Map<Domain.Entities.Notification.NotificationM>(request);

        // Varsayılan değerler
        notification.IsRead = false;

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Notification.NotificationM>().AddAsync(notification, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateNotificationCommandResponse(notification.Id);
    }

    public async System.Threading.Tasks.Task MarkAsReadAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification.NotificationM? notification = await _context.Set<Domain.Entities.Notification.NotificationM>()
            .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);

        if (notification is null)
            throw new Exception("Bildirim bulunamadı.");

        // Okundu olarak işaretle
        notification.IsRead = true;
        notification.ReadDate = DateTime.UtcNow;
        notification.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Notification.NotificationM>().Update(notification);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification.NotificationM? notification = await _context.Set<Domain.Entities.Notification.NotificationM>()
            .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);

        if (notification is null)
            throw new Exception("Bildirim bulunamadı.");

        // Hard delete (bildirimler soft delete yapılmaz, direkt silinir)
        _context.Set<Domain.Entities.Notification.NotificationM>().Remove(notification);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> GetAllAsync(GetAllNotificationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Notification.NotificationM> query = _context.Set<Domain.Entities.Notification.NotificationM>()
            .Include(n => n.User)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(n =>
                n.Title.ToLower().Contains(searchLower) ||
                n.Message.ToLower().Contains(searchLower)
            );
        }

        // Okunma durumu filtresi
        if (request.IsRead.HasValue)
        {
            query = query.Where(n => n.IsRead == request.IsRead.Value);
        }

        // Kullanıcı filtresi
        if (!string.IsNullOrEmpty(request.UserId))
        {
            query = query.Where(n => n.UserId == request.UserId);
        }

        // Bildirim tipi filtresi
        if (!string.IsNullOrEmpty(request.NotificationType))
        {
            query = query.Where(n => n.NotificationType == request.NotificationType);
        }

        // Sayfalama
        var notifications = await query
            .OrderByDescending(n => n.CreatedDate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return notifications;
    }

    public async Task<Domain.Entities.Notification.NotificationM> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Notification.NotificationM? notification = await _context.Set<Domain.Entities.Notification.NotificationM>()
            .Include(n => n.User)
            .FirstOrDefaultAsync(n => n.Id == id, cancellationToken);

        if (notification is null)
            throw new Exception("Bildirim bulunamadı.");

        return notification;
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> GetUnreadByUserAsync(string userId, CancellationToken cancellationToken)
    {
        var notifications = await _context.Set<Domain.Entities.Notification.NotificationM>()
            .Where(n => n.UserId == userId && !n.IsRead)
            .OrderByDescending(n => n.CreatedDate)
            .ToListAsync(cancellationToken);

        return notifications;
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> GetByUserAsync(string userId, int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var notifications = await _context.Set<Domain.Entities.Notification.NotificationM>()
            .Where(n => n.UserId == userId)
            .OrderByDescending(n => n.CreatedDate)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return notifications;
    }
}