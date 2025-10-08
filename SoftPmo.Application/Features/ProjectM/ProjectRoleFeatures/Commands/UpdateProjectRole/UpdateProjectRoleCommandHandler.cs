using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;

public sealed class UpdateProjectRoleCommandHandler : IRequestHandler<UpdateProjectRoleCommand, UpdateProjectRoleCommandResponse>
{
    private readonly IProjectRoleService _projectRoleService;

    public UpdateProjectRoleCommandHandler(IProjectRoleService projectRoleService)
    {
        _projectRoleService = projectRoleService;
    }

    public async Task<UpdateProjectRoleCommandResponse> Handle(UpdateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        await _projectRoleService.UpdateAsync(request, cancellationToken);
        return new UpdateProjectRoleCommandResponse();
    }
}