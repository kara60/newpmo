using MediatR;
using SoftPmo.Application.Services.ActivityM;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;

public sealed class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, UpdateActivityCommandResponse>
{
    private readonly IActivityService _activityService;

    public UpdateActivityCommandHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<UpdateActivityCommandResponse> Handle(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        await _activityService.UpdateAsync(request, cancellationToken);
        return new UpdateActivityCommandResponse();
    }
}