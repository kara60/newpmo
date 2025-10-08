using MediatR;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetNotificationById;

public sealed record GetNotificationByIdQuery(
    string Id
) : IRequest<Domain.Entities.Notification.NotificationM>;