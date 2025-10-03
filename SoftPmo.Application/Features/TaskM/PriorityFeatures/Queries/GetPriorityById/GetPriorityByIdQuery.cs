using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetPriorityById;

public sealed record GetPriorityByIdQuery(
    string Id
) : IRequest<Priority>;