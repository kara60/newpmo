using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;

public sealed record UpdatePositionCommand(
    string Id,
    string Name,
    string DepartmentId,
    string PositionLevelId,
    decimal BillingMultiplier,
    string Description,
    bool IsActive
) : IRequest<UpdatePositionCommandResponse>;