using MediatR;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetPriorityById;

public sealed class GetPriorityByIdQueryHandler : IRequestHandler<GetPriorityByIdQuery, Priority>
{
    private readonly IPriorityService _priorityService;

    public GetPriorityByIdQueryHandler(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    public async Task<Priority> Handle(GetPriorityByIdQuery request, CancellationToken cancellationToken)
    {
        var priority = await _priorityService.GetByIdAsync(request.Id, cancellationToken);
        return priority;
    }
}