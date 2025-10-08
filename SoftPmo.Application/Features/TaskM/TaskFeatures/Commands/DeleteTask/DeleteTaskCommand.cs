using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.DeleteTask;

public sealed record DeleteTaskCommand(
    string Id
) : IRequest<DeleteTaskCommandResponse>;