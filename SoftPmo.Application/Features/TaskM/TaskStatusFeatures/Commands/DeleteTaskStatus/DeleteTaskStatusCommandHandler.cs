using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.DeleteTaskStatus;

public sealed class DeleteTaskStatusCommandHandler : IRequestHandler<DeleteTaskStatusCommand, DeleteTaskStatusCommandResponse>
{
    private readonly ITaskStatusService _taskStatusService;

    public DeleteTaskStatusCommandHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<DeleteTaskStatusCommandResponse> Handle(DeleteTaskStatusCommand request, CancellationToken cancellationToken)
    {
        await _taskStatusService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteTaskStatusCommandResponse();
    }
}