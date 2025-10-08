using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetTaskStatusTypeById;

public sealed record GetTaskStatusTypeByIdQuery(
    string Id
) : IRequest<TaskStatusType>;