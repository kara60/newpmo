using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.DeleteTask;

public sealed class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, DeleteTaskCommandResponse>
{
    private readonly ITaskService _taskService;

    public DeleteTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<DeleteTaskCommandResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        await _taskService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteTaskCommandResponse();
    }
}