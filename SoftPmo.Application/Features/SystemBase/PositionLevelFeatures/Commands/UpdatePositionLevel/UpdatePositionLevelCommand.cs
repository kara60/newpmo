using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;

public sealed record UpdatePositionLevelCommand(
    string Id,
    string Name,
    decimal DefaultBillingMultiplier,
    int SortOrder,
    string ColorCode,
    string Description,
    bool IsActive
) : IRequest<UpdatePositionLevelCommandResponse>;