using MediatR;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.ApproveActivity;

public sealed record ApproveActivityCommand(
    string Id,
    string ApprovedByUserId,
    bool IsApproved,
    string? ApprovalNote
) : IRequest<ApproveActivityCommandResponse>;