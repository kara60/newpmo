using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetAllProjects;

public sealed class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IList<Domain.Entities.Project.ProjectM>>
{
    private readonly IProjectService _projectService;

    public GetAllProjectsQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IList<Domain.Entities.Project.ProjectM>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectService.GetAllAsync(request, cancellationToken);
        return projects;
    }
}