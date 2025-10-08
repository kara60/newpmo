using MediatR;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUnreadNotifications;

public sealed class GetUnreadNotificationsQueryHandler : IRequestHandler<GetUnreadNotificationsQuery, IList<Domain.Entities.Notification.NotificationM>>
{
    private readonly INotificationService _notificationService;

    public GetUnreadNotificationsQueryHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> Handle(GetUnreadNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationService.GetUnreadByUserAsync(request.UserId, cancellationToken);
        return notifications;
    }
}