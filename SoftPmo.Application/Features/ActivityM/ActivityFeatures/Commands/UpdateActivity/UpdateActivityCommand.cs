using MediatR;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;

public sealed record UpdateActivityCommand(
    string Id,
    string UserId,
    string TaskId,
    DateTime StartTime,
    DateTime EndTime,
    int DurationMinutes,
    string LocationId,
    string? CustomerLocationId,
    string? Description,
    bool IsActive
) : IRequest<UpdateActivityCommandResponse>;