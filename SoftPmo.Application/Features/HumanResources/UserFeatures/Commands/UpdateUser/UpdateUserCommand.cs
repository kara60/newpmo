using MediatR;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;

public sealed record UpdateUserCommand(
    string Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    DateTime StartDate,
    string DepartmentId,
    string PositionId,
    string? DirectManagerId,
    decimal BillingMultiplier,
    string? Description,
    bool IsActive
) : IRequest<UpdateUserCommandResponse>;