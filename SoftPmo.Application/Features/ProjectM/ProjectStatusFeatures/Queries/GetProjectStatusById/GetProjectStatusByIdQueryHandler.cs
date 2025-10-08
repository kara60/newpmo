using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetProjectStatusById;

public sealed class GetProjectStatusByIdQueryHandler : IRequestHandler<GetProjectStatusByIdQuery, ProjectStatus>
{
    private readonly IProjectStatusService _projectStatusService;

    public GetProjectStatusByIdQueryHandler(IProjectStatusService projectStatusService)
    {
        _projectStatusService = projectStatusService;
    }

    public async Task<ProjectStatus> Handle(GetProjectStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var projectStatus = await _projectStatusService.GetByIdAsync(request.Id, cancellationToken);
        return projectStatus;
    }
}