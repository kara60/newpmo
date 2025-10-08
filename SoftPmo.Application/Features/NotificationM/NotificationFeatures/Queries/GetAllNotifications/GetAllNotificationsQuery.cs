using MediatR;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetAllNotifications;

public sealed record GetAllNotificationsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsRead = null,
    string? UserId = null,
    string? NotificationType = null
) : IRequest<IList<Domain.Entities.Notification.NotificationM>>;