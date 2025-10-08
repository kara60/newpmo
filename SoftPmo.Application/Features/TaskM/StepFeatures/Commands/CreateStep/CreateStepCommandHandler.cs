using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;

public sealed class CreateStepCommandHandler : IRequestHandler<CreateStepCommand, CreateStepCommandResponse>
{
    private readonly IStepService _stepService;

    public CreateStepCommandHandler(IStepService stepService)
    {
        _stepService = stepService;
    }

    public async Task<CreateStepCommandResponse> Handle(CreateStepCommand request, CancellationToken cancellationToken)
    {
        var response = await _stepService.CreateAsync(request, cancellationToken);
        return response;
    }
}