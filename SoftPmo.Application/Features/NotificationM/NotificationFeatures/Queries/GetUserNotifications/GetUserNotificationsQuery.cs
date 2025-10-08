using MediatR;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUserNotifications;

public sealed record GetUserNotificationsQuery(
    string UserId,
    int PageNumber = 1,
    int PageSize = 20
) : IRequest<IList<Domain.Entities.Notification.NotificationM>>;