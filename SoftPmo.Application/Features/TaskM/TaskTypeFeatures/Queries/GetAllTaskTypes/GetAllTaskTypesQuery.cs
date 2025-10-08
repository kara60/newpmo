using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetAllTaskTypes;

public sealed record GetAllTaskTypesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? Category = null
) : IRequest<IList<TaskType>>;