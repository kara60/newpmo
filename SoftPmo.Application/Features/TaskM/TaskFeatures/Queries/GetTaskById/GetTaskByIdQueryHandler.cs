using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTaskById;

public sealed class GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Domain.Entities.Task.TaskM>
{
    private readonly ITaskService _taskService;

    public GetTaskByIdQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<Domain.Entities.Task.TaskM> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskService.GetByIdAsync(request.Id, cancellationToken);
        return task;
    }
}