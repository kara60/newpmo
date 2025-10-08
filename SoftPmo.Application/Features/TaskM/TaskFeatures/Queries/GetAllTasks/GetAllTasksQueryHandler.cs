using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetAllTasks;

public sealed class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, IList<Domain.Entities.Task.TaskM>>
{
    private readonly ITaskService _taskService;

    public GetAllTasksQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetAllAsync(request, cancellationToken);
        return tasks;
    }
}