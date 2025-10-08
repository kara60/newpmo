using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;

public sealed class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdateProjectCommandResponse>
{
    private readonly IProjectService _projectService;

    public UpdateProjectCommandHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<UpdateProjectCommandResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        await _projectService.UpdateAsync(request, cancellationToken);
        return new UpdateProjectCommandResponse();
    }
}