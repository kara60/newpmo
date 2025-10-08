using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.ChangeTaskStatus;

public sealed class ChangeTaskStatusCommandHandler : IRequestHandler<ChangeTaskStatusCommand, ChangeTaskStatusCommandResponse>
{
    private readonly ITaskService _taskService;

    public ChangeTaskStatusCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<ChangeTaskStatusCommandResponse> Handle(ChangeTaskStatusCommand request, CancellationToken cancellationToken)
    {
        await _taskService.ChangeStatusAsync(request.Id, request.TaskStatusId, cancellationToken);
        return new ChangeTaskStatusCommandResponse();
    }
}