using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.ChangeTaskStatus;

public sealed record ChangeTaskStatusCommand(
    string Id,
    string TaskStatusId
) : IRequest<ChangeTaskStatusCommandResponse>;