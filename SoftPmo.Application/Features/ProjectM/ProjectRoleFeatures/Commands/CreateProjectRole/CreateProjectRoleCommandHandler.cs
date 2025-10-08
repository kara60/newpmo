using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;

public sealed class CreateProjectRoleCommandHandler : IRequestHandler<CreateProjectRoleCommand, CreateProjectRoleCommandResponse>
{
    private readonly IProjectRoleService _projectRoleService;

    public CreateProjectRoleCommandHandler(IProjectRoleService projectRoleService)
    {
        _projectRoleService = projectRoleService;
    }

    public async Task<CreateProjectRoleCommandResponse> Handle(CreateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        var response = await _projectRoleService.CreateAsync(request, cancellationToken);
        return response;
    }
}