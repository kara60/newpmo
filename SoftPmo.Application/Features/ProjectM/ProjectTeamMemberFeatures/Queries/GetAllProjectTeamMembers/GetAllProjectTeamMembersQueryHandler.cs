using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetAllProjectTeamMembers;

public sealed class GetAllProjectTeamMembersQueryHandler : IRequestHandler<GetAllProjectTeamMembersQuery, IList<ProjectTeamMember>>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public GetAllProjectTeamMembersQueryHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<IList<ProjectTeamMember>> Handle(GetAllProjectTeamMembersQuery request, CancellationToken cancellationToken)
    {
        var projectTeamMembers = await _projectTeamMemberService.GetAllAsync(request, cancellationToken);
        return projectTeamMembers;
    }
}