using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTaskWithDetails;

public sealed record GetTaskWithDetailsQuery(
    string Id
) : IRequest<Domain.Entities.Task.TaskM>;