using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetAllSteps;

public sealed class GetAllStepsQueryHandler : IRequestHandler<GetAllStepsQuery, IList<Step>>
{
    private readonly IStepService _stepService;

    public GetAllStepsQueryHandler(IStepService stepService)
    {
        _stepService = stepService;
    }

    public async Task<IList<Step>> Handle(GetAllStepsQuery request, CancellationToken cancellationToken)
    {
        var steps = await _stepService.GetAllAsync(request, cancellationToken);
        return steps;
    }
}