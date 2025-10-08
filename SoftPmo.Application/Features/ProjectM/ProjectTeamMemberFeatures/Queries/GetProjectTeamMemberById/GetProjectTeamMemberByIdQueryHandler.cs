using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetProjectTeamMemberById;

public sealed class GetProjectTeamMemberByIdQueryHandler : IRequestHandler<GetProjectTeamMemberByIdQuery, ProjectTeamMember>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public GetProjectTeamMemberByIdQueryHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<ProjectTeamMember> Handle(GetProjectTeamMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var projectTeamMember = await _projectTeamMemberService.GetByIdAsync(request.Id, cancellationToken);
        return projectTeamMember;
    }
}