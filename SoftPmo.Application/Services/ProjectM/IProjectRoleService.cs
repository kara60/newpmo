using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetAllProjectRoles;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Services.ProjectM;

public interface IProjectRoleService
{
    Task<CreateProjectRoleCommandResponse> CreateAsync(CreateProjectRoleCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProjectRoleCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<ProjectRole>> GetAllAsync(GetAllProjectRolesQuery request, CancellationToken cancellationToken);
    Task<ProjectRole> GetByIdAsync(string id, CancellationToken cancellationToken);
}