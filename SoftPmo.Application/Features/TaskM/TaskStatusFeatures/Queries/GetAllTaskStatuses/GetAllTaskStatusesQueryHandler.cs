using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetAllTaskStatuses;

public sealed class GetAllTaskStatusesQueryHandler : IRequestHandler<GetAllTaskStatusesQuery, IList<Domain.Entities.Task.TaskStatus>>
{
    private readonly ITaskStatusService _taskStatusService;

    public GetAllTaskStatusesQueryHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<IList<Domain.Entities.Task.TaskStatus>> Handle(GetAllTaskStatusesQuery request, CancellationToken cancellationToken)
    {
        var taskStatuses = await _taskStatusService.GetAllAsync(request, cancellationToken);
        return taskStatuses;
    }
}