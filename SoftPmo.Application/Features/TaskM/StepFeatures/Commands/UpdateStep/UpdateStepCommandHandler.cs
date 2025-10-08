using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;

public sealed class UpdateStepCommandHandler : IRequestHandler<UpdateStepCommand, UpdateStepCommandResponse>
{
    private readonly IStepService _stepService;

    public UpdateStepCommandHandler(IStepService stepService)
    {
        _stepService = stepService;
    }

    public async Task<UpdateStepCommandResponse> Handle(UpdateStepCommand request, CancellationToken cancellationToken)
    {
        await _stepService.UpdateAsync(request, cancellationToken);
        return new UpdateStepCommandResponse();
    }
}