using MediatR;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUserNotifications;

public sealed class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, IList<Domain.Entities.Notification.NotificationM>>
{
    private readonly INotificationService _notificationService;

    public GetUserNotificationsQueryHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<IList<Domain.Entities.Notification.NotificationM>> Handle(GetUserNotificationsQuery request, CancellationToken cancellationToken)
    {
        var notifications = await _notificationService.GetByUserAsync(request.UserId, request.PageNumber, request.PageSize, cancellationToken);
        return notifications;
    }
}