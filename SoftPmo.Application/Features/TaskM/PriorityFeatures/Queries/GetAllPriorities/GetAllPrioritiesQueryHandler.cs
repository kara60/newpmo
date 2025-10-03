using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetAllPriorities;

public sealed class GetAllPrioritiesQueryHandler : IRequestHandler<GetAllPrioritiesQuery, IList<Priority>>
{
    private readonly IPriorityService _priorityService;

    public GetAllPrioritiesQueryHandler(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    public async Task<IList<Priority>> Handle(GetAllPrioritiesQuery request, CancellationToken cancellationToken)
    {
        var priorities = await _priorityService.GetAllAsync(request, cancellationToken);
        return priorities;
    }
}