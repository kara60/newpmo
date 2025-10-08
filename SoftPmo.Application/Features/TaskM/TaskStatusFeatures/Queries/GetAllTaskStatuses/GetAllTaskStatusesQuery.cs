using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetAllTaskStatuses;

public sealed record GetAllTaskStatusesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? TaskStatusTypeId = null
) : IRequest<IList<Domain.Entities.Task.TaskStatus>>;