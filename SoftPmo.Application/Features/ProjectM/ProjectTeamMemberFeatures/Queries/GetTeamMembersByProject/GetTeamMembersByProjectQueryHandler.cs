using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetTeamMembersByProject;

public sealed class GetTeamMembersByProjectQueryHandler : IRequestHandler<GetTeamMembersByProjectQuery, IList<ProjectTeamMember>>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public GetTeamMembersByProjectQueryHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<IList<ProjectTeamMember>> Handle(GetTeamMembersByProjectQuery request, CancellationToken cancellationToken)
    {
        var projectTeamMembers = await _projectTeamMemberService.GetByProjectAsync(request.ProjectId, cancellationToken);
        return projectTeamMembers;
    }
}