using MediatR;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUnreadNotifications;

public sealed record GetUnreadNotificationsQuery(
    string UserId
) : IRequest<IList<Domain.Entities.Notification.NotificationM>>;