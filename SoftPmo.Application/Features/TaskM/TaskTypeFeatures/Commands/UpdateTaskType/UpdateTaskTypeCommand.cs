using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;

public sealed record UpdateTaskTypeCommand(
    string Id,
    string Name,
    string? Category,
    string? ColorCode,
    string? IconCode,
    string? Description,
    bool IsActive
) : IRequest<UpdateTaskTypeCommandResponse>;