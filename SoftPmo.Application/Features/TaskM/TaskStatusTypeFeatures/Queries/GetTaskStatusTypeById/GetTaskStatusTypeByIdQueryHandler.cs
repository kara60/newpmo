using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetTaskStatusTypeById;

public sealed class GetTaskStatusTypeByIdQueryHandler : IRequestHandler<GetTaskStatusTypeByIdQuery, TaskStatusType>
{
    private readonly ITaskStatusTypeService _taskStatusTypeService;

    public GetTaskStatusTypeByIdQueryHandler(ITaskStatusTypeService taskStatusTypeService)
    {
        _taskStatusTypeService = taskStatusTypeService;
    }

    public async Task<TaskStatusType> Handle(GetTaskStatusTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var taskStatusType = await _taskStatusTypeService.GetByIdAsync(request.Id, cancellationToken);
        return taskStatusType;
    }
}