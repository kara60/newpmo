using MediatR;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;

public sealed record UpdatePriorityCommand(
    string Id,
    string Name,
    int SortOrder,
    string? ColorCode,
    string? IconCode,
    string? Description,
    bool IsActive
) : IRequest<UpdatePriorityCommandResponse>;