using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.DeleteProject;

public sealed class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeleteProjectCommandResponse>
{
    private readonly IProjectService _projectService;

    public DeleteProjectCommandHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<DeleteProjectCommandResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        await _projectService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteProjectCommandResponse();
    }
}