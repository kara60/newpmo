using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusById;

public sealed record GetTaskStatusByIdQuery(
    string Id
) : IRequest<Domain.Entities.Task.TaskStatus>;