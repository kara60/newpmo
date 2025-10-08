using MediatR;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetPendingApprovals;

public sealed class GetPendingApprovalsQueryHandler : IRequestHandler<GetPendingApprovalsQuery, IList<Domain.Entities.Activity.ActivityM>>
{
    private readonly IActivityService _activityService;

    public GetPendingApprovalsQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<IList<Domain.Entities.Activity.ActivityM>> Handle(GetPendingApprovalsQuery request, CancellationToken cancellationToken)
    {
        var activities = await _activityService.GetPendingApprovalsAsync(request.ManagerId, cancellationToken);
        return activities;
    }
}