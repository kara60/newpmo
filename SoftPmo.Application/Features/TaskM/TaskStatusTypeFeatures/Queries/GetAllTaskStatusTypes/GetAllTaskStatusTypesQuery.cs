using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetAllTaskStatusTypes;

public sealed record GetAllTaskStatusTypesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<TaskStatusType>>;