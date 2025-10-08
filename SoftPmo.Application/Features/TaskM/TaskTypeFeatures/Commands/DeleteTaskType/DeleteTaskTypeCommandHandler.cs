using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.DeleteTaskType;

public sealed class DeleteTaskTypeCommandHandler : IRequestHandler<DeleteTaskTypeCommand, DeleteTaskTypeCommandResponse>
{
    private readonly ITaskTypeService _taskTypeService;

    public DeleteTaskTypeCommandHandler(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
    }

    public async Task<DeleteTaskTypeCommandResponse> Handle(DeleteTaskTypeCommand request, CancellationToken cancellationToken)
    {
        await _taskTypeService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteTaskTypeCommandResponse();
    }
}