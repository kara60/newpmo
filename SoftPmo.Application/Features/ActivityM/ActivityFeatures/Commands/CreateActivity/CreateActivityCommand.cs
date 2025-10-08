using MediatR;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;

public sealed record CreateActivityCommand(
    string UserId,
    string TaskId,
    DateTime StartTime,
    DateTime EndTime,
    int DurationMinutes,
    string LocationId,
    string? CustomerLocationId,
    string? Description
) : IRequest<CreateActivityCommandResponse>;