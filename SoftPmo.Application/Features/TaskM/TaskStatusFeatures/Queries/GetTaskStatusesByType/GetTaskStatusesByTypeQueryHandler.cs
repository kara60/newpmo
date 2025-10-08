using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusesByType;

public sealed class GetTaskStatusesByTypeQueryHandler : IRequestHandler<GetTaskStatusesByTypeQuery, IList<Domain.Entities.Task.TaskStatus>>
{
    private readonly ITaskStatusService _taskStatusService;

    public GetTaskStatusesByTypeQueryHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<IList<Domain.Entities.Task.TaskStatus>> Handle(GetTaskStatusesByTypeQuery request, CancellationToken cancellationToken)
    {
        var taskStatuses = await _taskStatusService.GetByTypeAsync(request.TaskStatusTypeId, cancellationToken);
        return taskStatuses;
    }
}