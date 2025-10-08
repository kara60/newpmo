using MediatR;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetAllUsers;

public sealed record GetAllUsersQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? DepartmentId = null,
    string? PositionId = null
) : IRequest<IList<User>>;