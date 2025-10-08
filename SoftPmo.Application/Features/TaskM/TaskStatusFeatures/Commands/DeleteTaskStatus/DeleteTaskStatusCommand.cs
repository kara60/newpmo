using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.DeleteTaskStatus;

public sealed record DeleteTaskStatusCommand(
    string Id
) : IRequest<DeleteTaskStatusCommandResponse>;