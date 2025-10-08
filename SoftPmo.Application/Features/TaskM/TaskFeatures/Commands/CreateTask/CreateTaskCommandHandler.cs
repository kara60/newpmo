using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;

public sealed class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
{
    private readonly ITaskService _taskService;

    public CreateTaskCommandHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        var response = await _taskService.CreateAsync(request, cancellationToken);
        return response;
    }
}