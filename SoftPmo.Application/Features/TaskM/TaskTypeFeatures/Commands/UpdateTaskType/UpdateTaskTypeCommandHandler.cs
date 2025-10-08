using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;

public sealed class UpdateTaskTypeCommandHandler : IRequestHandler<UpdateTaskTypeCommand, UpdateTaskTypeCommandResponse>
{
    private readonly ITaskTypeService _taskTypeService;

    public UpdateTaskTypeCommandHandler(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
    }

    public async Task<UpdateTaskTypeCommandResponse> Handle(UpdateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        await _taskTypeService.UpdateAsync(request, cancellationToken);
        return new UpdateTaskTypeCommandResponse();
    }
}