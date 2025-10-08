using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetAllProjectRoles;

public sealed record GetAllProjectRolesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<ProjectRole>>;