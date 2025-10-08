using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetAllProjectRoles;

public sealed class GetAllProjectRolesQueryHandler : IRequestHandler<GetAllProjectRolesQuery, IList<ProjectRole>>
{
    private readonly IProjectRoleService _projectRoleService;

    public GetAllProjectRolesQueryHandler(IProjectRoleService projectRoleService)
    {
        _projectRoleService = projectRoleService;
    }

    public async Task<IList<ProjectRole>> Handle(GetAllProjectRolesQuery request, CancellationToken cancellationToken)
    {
        var projectRoles = await _projectRoleService.GetAllAsync(request, cancellationToken);
        return projectRoles;
    }
}