using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetProjectRoleById;

public sealed class GetProjectRoleByIdQueryHandler : IRequestHandler<GetProjectRoleByIdQuery, ProjectRole>
{
    private readonly IProjectRoleService _projectRoleService;

    public GetProjectRoleByIdQueryHandler(IProjectRoleService projectRoleService)
    {
        _projectRoleService = projectRoleService;
    }

    public async Task<ProjectRole> Handle(GetProjectRoleByIdQuery request, CancellationToken cancellationToken)
    {
        var projectRole = await _projectRoleService.GetByIdAsync(request.Id, cancellationToken);
        return projectRole;
    }
}