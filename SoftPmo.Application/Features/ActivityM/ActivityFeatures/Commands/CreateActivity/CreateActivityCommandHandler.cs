using MediatR;
using SoftPmo.Application.Services.ActivityM;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;

public sealed class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, CreateActivityCommandResponse>
{
    private readonly IActivityService _activityService;

    public CreateActivityCommandHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<CreateActivityCommandResponse> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        var response = await _activityService.CreateAsync(request, cancellationToken);
        return response;
    }
}