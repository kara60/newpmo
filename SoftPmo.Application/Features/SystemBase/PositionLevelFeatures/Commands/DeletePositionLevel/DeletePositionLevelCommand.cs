using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.DeletePositionLevel;

public sealed record DeletePositionLevelCommand(
    string Id
) : IRequest<DeletePositionLevelCommandResponse>;