using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetAllProjectTeamMembers;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Services.ProjectM;

public interface IProjectTeamMemberService
{
    Task<CreateProjectTeamMemberCommandResponse> CreateAsync(CreateProjectTeamMemberCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProjectTeamMemberCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<ProjectTeamMember>> GetAllAsync(GetAllProjectTeamMembersQuery request, CancellationToken cancellationToken);
    Task<ProjectTeamMember> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<ProjectTeamMember>> GetByProjectAsync(string projectId, CancellationToken cancellationToken);
}