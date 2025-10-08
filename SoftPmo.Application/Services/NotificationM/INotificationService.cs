using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetAllNotifications;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Services.NotificationM;

public interface INotificationService
{
    Task<CreateNotificationCommandResponse> CreateAsync(CreateNotificationCommand request, CancellationToken cancellationToken);
    Task MarkAsReadAsync(string id, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Notification.NotificationM>> GetAllAsync(GetAllNotificationsQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Notification.NotificationM> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Notification.NotificationM>> GetUnreadByUserAsync(string userId, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Notification.NotificationM>> GetByUserAsync(string userId, int pageNumber, int pageSize, CancellationToken cancellationToken);
}