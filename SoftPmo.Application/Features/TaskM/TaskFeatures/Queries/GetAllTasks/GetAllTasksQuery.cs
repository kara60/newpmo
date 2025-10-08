using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetAllTasks;

public sealed record GetAllTasksQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? CustomerId = null,
    string? ProjectId = null,
    string? MainResponsibleUserId = null,
    string? TaskStatusId = null,
    string? PriorityId = null
) : IRequest<IList<Domain.Entities.Task.TaskM>>;