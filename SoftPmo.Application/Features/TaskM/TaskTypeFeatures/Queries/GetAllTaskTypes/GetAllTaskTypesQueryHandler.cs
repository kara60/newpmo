using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetAllTaskTypes;

public sealed class GetAllTaskTypesQueryHandler : IRequestHandler<GetAllTaskTypesQuery, IList<TaskType>>
{
    private readonly ITaskTypeService _taskTypeService;

    public GetAllTaskTypesQueryHandler(ITaskTypeService taskTypeService)
    {
        _taskTypeService = taskTypeService;
    }

    public async Task<IList<TaskType>> Handle(GetAllTaskTypesQuery request, CancellationToken cancellationToken)
    {
        var taskTypes = await _taskTypeService.GetAllAsync(request, cancellationToken);
        return taskTypes;
    }
}