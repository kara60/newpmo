using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.DeleteStep;

public sealed class DeleteStepCommandHandler : IRequestHandler<DeleteStepCommand, DeleteStepCommandResponse>
{
    private readonly IStepService _stepService;

    public DeleteStepCommandHandler(IStepService stepService)
    {
        _stepService = stepService;
    }

    public async Task<DeleteStepCommandResponse> Handle(DeleteStepCommand request, CancellationToken cancellationToken)
    {
        await _stepService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteStepCommandResponse();
    }
}