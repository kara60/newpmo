using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;

public sealed record UpdateTaskStatusCommand(
    string Id,
    string Name,
    string TaskStatusTypeId,
    int SortOrder,
    string? ColorCode,
    string? Description,
    bool IsActive
) : IRequest<UpdateTaskStatusCommandResponse>;