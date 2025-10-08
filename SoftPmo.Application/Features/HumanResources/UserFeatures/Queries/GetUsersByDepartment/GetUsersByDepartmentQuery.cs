using MediatR;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUsersByDepartment;

public sealed record GetUsersByDepartmentQuery(
    string DepartmentId
) : IRequest<IList<User>>;