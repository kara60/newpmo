using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetAllTaskStatusTypes;

public sealed class GetAllTaskStatusTypesQueryHandler : IRequestHandler<GetAllTaskStatusTypesQuery, IList<TaskStatusType>>
{
    private readonly ITaskStatusTypeService _taskStatusTypeService;

    public GetAllTaskStatusTypesQueryHandler(ITaskStatusTypeService taskStatusTypeService)
    {
        _taskStatusTypeService = taskStatusTypeService;
    }

    public async Task<IList<TaskStatusType>> Handle(GetAllTaskStatusTypesQuery request, CancellationToken cancellationToken)
    {
        var taskStatusTypes = await _taskStatusTypeService.GetAllAsync(request, cancellationToken);
        return taskStatusTypes;
    }
}