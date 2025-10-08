using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;

public sealed class UpdateTaskStatusTypeCommandHandler : IRequestHandler<UpdateTaskStatusTypeCommand, UpdateTaskStatusTypeCommandResponse>
{
    private readonly ITaskStatusTypeService _taskStatusTypeService;

    public UpdateTaskStatusTypeCommandHandler(ITaskStatusTypeService taskStatusTypeService)
    {
        _taskStatusTypeService = taskStatusTypeService;
    }

    public async Task<UpdateTaskStatusTypeCommandResponse> Handle(UpdateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        await _taskStatusTypeService.UpdateAsync(request, cancellationToken);
        return new UpdateTaskStatusTypeCommandResponse();
    }
}