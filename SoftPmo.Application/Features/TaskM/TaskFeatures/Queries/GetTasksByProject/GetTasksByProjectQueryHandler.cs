using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTasksByProject;

public sealed class GetTasksByProjectQueryHandler : IRequestHandler<GetTasksByProjectQuery, IList<Domain.Entities.Task.TaskM>>
{
    private readonly ITaskService _taskService;

    public GetTasksByProjectQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> Handle(GetTasksByProjectQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetByProjectAsync(request.ProjectId, cancellationToken);
        return tasks;
    }
}