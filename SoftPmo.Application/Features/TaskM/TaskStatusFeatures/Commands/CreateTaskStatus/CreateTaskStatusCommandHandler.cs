using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;

public sealed class CreateTaskStatusCommandHandler : IRequestHandler<CreateTaskStatusCommand, CreateTaskStatusCommandResponse>
{
    private readonly ITaskStatusService _taskStatusService;

    public CreateTaskStatusCommandHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<CreateTaskStatusCommandResponse> Handle(CreateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var response = await _taskStatusService.CreateAsync(request, cancellationToken);
        return response;
    }
}