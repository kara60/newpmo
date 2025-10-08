using MediatR;
using SoftPmo.Application.Services.ActivityM;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.ApproveActivity;

public sealed class ApproveActivityCommandHandler : IRequestHandler<ApproveActivityCommand, ApproveActivityCommandResponse>
{
    private readonly IActivityService _activityService;

    public ApproveActivityCommandHandler(IActivityService activityService)
    {
        _activityService = activityService;
    }

    public async Task<ApproveActivityCommandResponse> Handle(ApproveActivityCommand request, CancellationToken cancellationToken)
    {
        await _activityService.ApproveAsync(request.Id, request.ApprovedByUserId, request.IsApproved, request.ApprovalNote, cancellationToken);
        return new ApproveActivityCommandResponse();
    }
}