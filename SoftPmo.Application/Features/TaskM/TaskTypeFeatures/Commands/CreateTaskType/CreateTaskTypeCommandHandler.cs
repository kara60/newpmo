using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;

public sealed class CreateTaskTypeCommandHandler : IRequestHandler<CreateTaskTypeCommand, CreateTaskTypeCommandResponse>
{
    private readonly ITaskTypeService _taskTypeService;

    public CreateTaskTypeCommandHandler(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
    }

    public async Task<CreateTaskTypeCommandResponse> Handle(CreateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await _taskTypeService.CreateAsync(request, cancellationToken);
        return response;
    }
}