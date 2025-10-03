using MediatR;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.DeletePriority;

public sealed record DeletePriorityCommand(
    string Id
) : IRequest<DeletePriorityCommandResponse>;