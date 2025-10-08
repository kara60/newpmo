using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;

public sealed class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreateProjectCommandResponse>
{
    private readonly IProjectService _projectService;

    public CreateProjectCommandHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<CreateProjectCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var response = await _projectService.CreateAsync(request, cancellationToken);
        return response;
    }
}