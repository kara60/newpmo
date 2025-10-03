using MediatR;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;

public sealed record CreatePriorityCommand(
    string Name,
    int SortOrder,
    string? ColorCode,
    string? IconCode,
    string? Description
) : IRequest<CreatePriorityCommandResponse>;