using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.DeleteTaskType;

public sealed record DeleteTaskTypeCommand(
    string Id
) : IRequest<DeleteTaskTypeCommandResponse>;