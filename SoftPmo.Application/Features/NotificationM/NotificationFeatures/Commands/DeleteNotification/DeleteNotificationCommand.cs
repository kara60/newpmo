using MediatR;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.DeleteNotification;

public sealed record DeleteNotificationCommand(
    string Id
) : IRequest<DeleteNotificationCommandResponse>;