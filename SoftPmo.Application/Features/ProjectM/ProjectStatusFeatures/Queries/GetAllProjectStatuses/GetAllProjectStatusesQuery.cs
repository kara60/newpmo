using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetAllProjectStatuses;

public sealed record GetAllProjectStatusesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? StatusType = null
) : IRequest<IList<ProjectStatus>>;