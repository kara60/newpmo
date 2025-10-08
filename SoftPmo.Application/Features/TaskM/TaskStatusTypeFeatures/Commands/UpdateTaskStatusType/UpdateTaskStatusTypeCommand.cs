using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;

public sealed record UpdateTaskStatusTypeCommand(
    string Id,
    string Name,
    string StatusCategory,
    string? Description,
    bool IsActive
) : IRequest<UpdateTaskStatusTypeCommandResponse>;