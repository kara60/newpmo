using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.DeletePosition;

public sealed record DeletePositionCommand(
    string Id
) : IRequest<DeletePositionCommandResponse>;