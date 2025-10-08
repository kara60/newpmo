using MediatR;
using SoftPmo.Application.Services.ActivityM;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivityById;

public sealed class GetActivityByIdQueryHandler : IRequestHandler<GetActivityByIdQuery, Domain.Entities.Activity.ActivityM>
{
    private readonly IActivityService _activityService;

    public GetActivityByIdQueryHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<Domain.Entities.Activity.ActivityM> Handle(GetActivityByIdQuery request, CancellationToken cancellationToken)
    {
        var activity = await _activityService.GetByIdAsync(request.Id, cancellationToken);
        return activity;
    }
}