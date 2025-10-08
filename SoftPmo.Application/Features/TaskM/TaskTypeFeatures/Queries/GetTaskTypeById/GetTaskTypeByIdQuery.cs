using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetTaskTypeById;

public sealed record GetTaskTypeByIdQuery(
    string Id
) : IRequest<TaskType>;