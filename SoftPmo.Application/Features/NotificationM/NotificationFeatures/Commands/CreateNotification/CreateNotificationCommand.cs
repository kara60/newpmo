using MediatR;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;

public sealed record CreateNotificationCommand(
    string UserId,
    string Title,
    string Message,
    string NotificationType,
    string? RelatedEntityId,
    string? RelatedEntityType
) : IRequest<CreateNotificationCommandResponse>;