using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.UpdateTask;

public sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResponse>
{
    private readonly ITaskService _taskService;

    public UpdateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<UpdateTaskCommandResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        await _taskService.UpdateAsync(request, cancellationToken);
        return new UpdateTaskCommandResponse();
    }
}