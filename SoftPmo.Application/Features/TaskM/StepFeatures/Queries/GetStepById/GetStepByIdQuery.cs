using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetStepById;

public sealed record GetStepByIdQuery(
    string Id
) : IRequest<Step>;