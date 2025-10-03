using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;

public sealed record CreatePositionLevelCommand(
    string Name,
    decimal DefaultBillingMultiplier,
    int SortOrder,
    string ColorCode,
    string Description
) : IRequest<CreatePositionLevelCommandResponse>;