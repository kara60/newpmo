using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;

public sealed class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand, UpdateTaskStatusCommandResponse>
{
    private readonly ITaskStatusService _taskStatusService;

    public UpdateTaskStatusCommandHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<UpdateTaskStatusCommandResponse> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        await _taskStatusService.UpdateAsync(request, cancellationToken);
        return new UpdateTaskStatusCommandResponse();
    }
}