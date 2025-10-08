using MediatR;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetAllNotifications;

public sealed class GetAllNotificationsQueryHandler : IRequestHandler<GetAllNotificationsQuery, IList<Domain.Entities.Notification.NotificationM>>
{
    private readonly INotificationService _notificationService;

    public GetAllNotificationsQueryHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> Handle(GetAllNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationService.GetAllAsync(request, cancellationToken);
        return notifications;
    }
}