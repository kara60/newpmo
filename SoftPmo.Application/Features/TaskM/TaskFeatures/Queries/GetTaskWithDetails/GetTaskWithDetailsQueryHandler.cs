using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTaskWithDetails;

public sealed class GetTaskWithDetailsQueryHandler : IRequestHandler<GetTaskWithDetailsQuery, Domain.Entities.Task.TaskM>
{
    private readonly ITaskService _taskService;

    public GetTaskWithDetailsQueryHandler(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public async Task<Domain.Entities.Task.TaskM> Handle(GetTaskWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var task = await _taskService.GetWithDetailsAsync(request.Id, cancellationToken);
        return task;
    }
}