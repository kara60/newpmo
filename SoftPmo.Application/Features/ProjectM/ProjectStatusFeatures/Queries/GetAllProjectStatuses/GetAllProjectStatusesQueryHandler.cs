using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetAllProjectStatuses;

public sealed class GetAllProjectStatusesQueryHandler : IRequestHandler<GetAllProjectStatusesQuery, IList<ProjectStatus>>
{
    private readonly IProjectStatusService _projectStatusService;

    public GetAllProjectStatusesQueryHandler(IProjectStatusService projectStatusService)
    {
        _projectStatusService = projectStatusService;
    }

    public async Task<IList<ProjectStatus>> Handle(GetAllProjectStatusesQuery request, CancellationToken cancellationToken)
    {
        var projectStatuses = await _projectStatusService.GetAllAsync(request, cancellationToken);
        return projectStatuses;
    }
}