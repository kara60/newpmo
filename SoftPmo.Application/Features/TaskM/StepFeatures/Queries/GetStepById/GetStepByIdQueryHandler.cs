using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetStepById;

public sealed class GetStepByIdQueryHandler : IRequestHandler<GetStepByIdQuery, Step>
{
    private readonly IStepService _stepService;

    public GetStepByIdQueryHandler(IStepService stepService)
    {
        _stepService = stepService;
    }

    public async Task<Step> Handle(GetStepByIdQuery request, CancellationToken cancellationToken)
    {
        var step = await _stepService.GetByIdAsync(request.Id, cancellationToken);
        return step;
    }
}