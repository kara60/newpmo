using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;

public sealed record CreateTaskStatusCommand(
    string Name,
    string TaskStatusTypeId,
    int SortOrder,
    string? ColorCode,
    string? Description
) : IRequest<CreateTaskStatusCommandResponse>;