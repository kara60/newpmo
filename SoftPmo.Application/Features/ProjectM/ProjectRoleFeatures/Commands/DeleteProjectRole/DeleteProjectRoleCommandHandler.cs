using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.DeleteProjectRole;

public sealed class DeleteProjectRoleCommandHandler : IRequestHandler<DeleteProjectRoleCommand, DeleteProjectRoleCommandResponse>
{
    private readonly IProjectRoleService _projectRoleService;

    public DeleteProjectRoleCommandHandler(IProjectRoleService projectRoleService)
    {
        _projectRoleService = projectRoleService;
    }

    public async Task<DeleteProjectRoleCommandResponse> Handle(DeleteProjectRoleCommand request, CancellationToken cancellationToken)
    {
        await _projectRoleService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteProjectRoleCommandResponse();
    }
}