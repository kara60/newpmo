using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;

public sealed class UpdateProjectTeamMemberCommandHandler : IRequestHandler<UpdateProjectTeamMemberCommand, UpdateProjectTeamMemberCommandResponse>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public UpdateProjectTeamMemberCommandHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<UpdateProjectTeamMemberCommandResponse> Handle(UpdateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        await _projectTeamMemberService.UpdateAsync(request, cancellationToken);
        return new UpdateProjectTeamMemberCommandResponse();
    }
}