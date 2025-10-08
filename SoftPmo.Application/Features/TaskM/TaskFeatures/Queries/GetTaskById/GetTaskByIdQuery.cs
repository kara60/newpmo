using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTaskById;

public sealed record GetTaskByIdQuery(
    string Id
) : IRequest<Domain.Entities.Task.TaskM>;