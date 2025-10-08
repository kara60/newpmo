using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectWithDetails;

public sealed class GetProjectWithDetailsQueryHandler : IRequestHandler<GetProjectWithDetailsQuery, Domain.Entities.Project.ProjectM>
{
    private readonly IProjectService _projectService;

    public GetProjectWithDetailsQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<Domain.Entities.Project.ProjectM> Handle(GetProjectWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectService.GetWithDetailsAsync(request.Id, cancellationToken);
        return project;
    }
}