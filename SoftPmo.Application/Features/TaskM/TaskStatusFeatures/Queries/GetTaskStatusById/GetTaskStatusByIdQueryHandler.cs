using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusById;

public sealed class GetTaskStatusByIdQueryHandler : IRequestHandler<GetTaskStatusByIdQuery, Domain.Entities.Task.TaskStatus>
{
    private readonly ITaskStatusService _taskStatusService;

    public GetTaskStatusByIdQueryHandler(ITaskStatusService taskStatusService)
    {
        _taskStatusService = taskStatusService;
    }

    public async Task<Domain.Entities.Task.TaskStatus> Handle(GetTaskStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var taskStatus = await _taskStatusService.GetByIdAsync(request.Id, cancellationToken);
        return taskStatus;
    }
}