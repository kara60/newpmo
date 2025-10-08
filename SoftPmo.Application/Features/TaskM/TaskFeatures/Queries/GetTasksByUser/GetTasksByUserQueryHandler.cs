using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTasksByUser;

public sealed class GetTasksByUserQueryHandler : IRequestHandler<GetTasksByUserQuery, IList<Domain.Entities.Task.TaskM>>
{
    private readonly ITaskService _taskService;

    public GetTasksByUserQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<IList<Domain.Entities.Task.TaskM>> Handle(GetTasksByUserQuery request, CancellationToken cancellationToken)
    {
        var tasks = await _taskService.GetByUserAsync(request.UserId, cancellationToken);
        return tasks;
    }
}