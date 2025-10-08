using MediatR;
using SoftPmo.Application.Services.ActivityM;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.DeleteActivity;

public sealed class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, DeleteActivityCommandResponse>
{
    private readonly IActivityService _activityService;

    public DeleteActivityCommandHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<DeleteActivityCommandResponse> Handle(DeleteActivityCommand request, CancellationToken cancellationToken)
    {
        await _activityService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteActivityCommandResponse();
    }
}