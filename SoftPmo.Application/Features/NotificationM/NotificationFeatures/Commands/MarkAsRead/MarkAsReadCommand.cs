using MediatR;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.MarkAsRead;

public sealed record MarkAsReadCommand(
    string Id
) : IRequest<MarkAsReadCommandResponse>;