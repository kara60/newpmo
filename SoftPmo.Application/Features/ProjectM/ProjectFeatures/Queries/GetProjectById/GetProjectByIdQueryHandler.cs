using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectById;

public sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Domain.Entities.Project.ProjectM>
{
    private readonly IProjectService _projectService;

    public GetProjectByIdQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<Domain.Entities.Project.ProjectM> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectService.GetByIdAsync(request.Id, cancellationToken);
        return project;
    }
}