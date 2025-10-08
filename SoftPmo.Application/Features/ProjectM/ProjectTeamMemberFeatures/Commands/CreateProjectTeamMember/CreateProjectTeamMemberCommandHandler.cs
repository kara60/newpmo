using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;

public sealed class CreateProjectTeamMemberCommandHandler : IRequestHandler<CreateProjectTeamMemberCommand, CreateProjectTeamMemberCommandResponse>
{
    private readonly IProjectTeamMemberService _projectTeamMemberService;

    public CreateProjectTeamMemberCommandHandler(IProjectTeamMemberService projectTeamMemberService)
    {
        _projectTeamMemberService = projectTeamMemberService;
    }

    public async Task<CreateProjectTeamMemberCommandResponse> Handle(CreateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        var response = await _projectTeamMemberService.CreateAsync(request, cancellationToken);
        return response;
    }
}