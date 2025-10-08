using MediatR;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByTask;

public sealed class GetActivitiesByTaskQueryHandler : IRequestHandler<GetActivitiesByTaskQuery, IList<Domain.Entities.Activity.ActivityM>>
{
    private readonly IActivityService _activityService;

    public GetActivitiesByTaskQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> Handle(GetActivitiesByTaskQuery request, CancellationToken cancellationToken)
    {
        var activities = await _activityService.GetByTaskAsync(request.TaskId, cancellationToken);
        return activities;
    }
}