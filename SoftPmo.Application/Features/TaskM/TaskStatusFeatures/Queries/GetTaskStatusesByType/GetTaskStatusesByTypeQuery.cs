using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusesByType;

public sealed record GetTaskStatusesByTypeQuery(
    string TaskStatusTypeId
) : IRequest<IList<Domain.Entities.Task.TaskStatus>>;