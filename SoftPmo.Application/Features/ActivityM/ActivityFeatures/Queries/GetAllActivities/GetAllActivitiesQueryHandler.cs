using MediatR;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetAllActivities;

public sealed class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, IList<Domain.Entities.Activity.ActivityM>>
{
    private readonly IActivityService _activityService;

    public GetAllActivitiesQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        var activities = await _activityService.GetAllAsync(request, cancellationToken);
        return activities;
    }
}