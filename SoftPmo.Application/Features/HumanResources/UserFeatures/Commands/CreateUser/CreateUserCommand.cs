using MediatR;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    DateTime StartDate,
    string DepartmentId,
    string PositionId,
    string? DirectManagerId,
    decimal BillingMultiplier,
    string? Description
) : IRequest<CreateUserCommandResponse>;