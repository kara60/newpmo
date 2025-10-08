using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;

public sealed class CreateTaskStatusTypeCommandHandler : IRequestHandler<CreateTaskStatusTypeCommand, CreateTaskStatusTypeCommandResponse>
{
    private readonly ITaskStatusTypeService _taskStatusTypeService;

    public CreateTaskStatusTypeCommandHandler(ITaskStatusTypeService taskStatusTypeService)
    {
        _taskStatusTypeService = taskStatusTypeService;
    }

    public async Task<CreateTaskStatusTypeCommandResponse> Handle(CreateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await _taskStatusTypeService.CreateAsync(request, cancellationToken);
        return response;
    }
}