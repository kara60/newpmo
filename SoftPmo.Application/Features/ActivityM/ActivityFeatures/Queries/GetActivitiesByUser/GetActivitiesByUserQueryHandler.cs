using MediatR;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByUser;

public sealed class GetActivitiesByUserQueryHandler : IRequestHandler<GetActivitiesByUserQuery, IList<Domain.Entities.Activity.ActivityM>>
{
    private readonly IActivityService _activityService;

    public GetActivitiesByUserQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> Handle(GetActivitiesByUserQuery request, CancellationToken cancellationToken)
    {
        var activities = await _activityService.GetByUserAsync(request.UserId, request.StartDate, request.EndDate, cancellationToken);
        return activities;
    }
}