using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.DeleteTaskStatusType;

public sealed record DeleteTaskStatusTypeCommand(
    string Id
) : IRequest<DeleteTaskStatusTypeCommandResponse>;