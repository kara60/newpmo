using MediatR;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;

public sealed record CreatePositionCommand(
    string Name,
    string DepartmentId,
    string PositionLevelId,
    decimal BillingMultiplier,
    string Description
) : IRequest<CreatePositionCommandResponse>;