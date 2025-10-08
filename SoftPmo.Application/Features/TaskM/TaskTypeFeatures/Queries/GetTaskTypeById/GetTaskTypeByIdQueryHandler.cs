using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetTaskTypeById;

public sealed class GetTaskTypeByIdQueryHandler : IRequestHandler<GetTaskTypeByIdQuery, TaskType>
{
    private readonly ITaskTypeService _taskTypeService;

    public GetTaskTypeByIdQueryHandler(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
    }

    public async Task<TaskType> Handle(GetTaskTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var taskType = await _taskTypeService.GetByIdAsync(request.Id, cancellationToken);
        return taskType;
    }
}