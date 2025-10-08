using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetAllSteps;

public sealed record GetAllStepsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<Step>>;