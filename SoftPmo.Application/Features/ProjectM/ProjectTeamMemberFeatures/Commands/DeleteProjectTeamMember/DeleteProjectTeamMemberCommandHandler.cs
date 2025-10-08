using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.DeleteProjectTeamMember;

public sealed class DeleteProjectTeamMemberCommandHandler : IRequestHandler<DeleteProjectTeamMemberCommand, DeleteProjectTeamMemberCommandResponse>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public DeleteProjectTeamMemberCommandHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<DeleteProjectTeamMemberCommandResponse> Handle(DeleteProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        await _projectTeamMemberService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteProjectTeamMemberCommandResponse();
    }
}