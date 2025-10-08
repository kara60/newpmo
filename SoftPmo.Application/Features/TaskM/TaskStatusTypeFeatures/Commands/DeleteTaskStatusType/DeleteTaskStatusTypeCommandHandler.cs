using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.DeleteTaskStatusType;

public sealed class DeleteTaskStatusTypeCommandHandler : IRequestHandler<DeleteTaskStatusTypeCommand, DeleteTaskStatusTypeCommandResponse>
{
    private readonly ITaskStatusTypeService _taskStatusTypeService;

    public DeleteTaskStatusTypeCommandHandler(ITaskStatusTypeService taskStatusTypeService)
    {
        _taskStatusTypeService = taskStatusTypeService;
    }

    public async Task<DeleteTaskStatusTypeCommandResponse> Handle(DeleteTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        await _taskStatusTypeService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteTaskStatusTypeCommandResponse();
    }
}