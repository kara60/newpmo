using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTasksByUser;

public sealed record GetTasksByUserQuery(
    string UserId
) : IRequest<IList<Domain.Entities.Task.TaskM>>;