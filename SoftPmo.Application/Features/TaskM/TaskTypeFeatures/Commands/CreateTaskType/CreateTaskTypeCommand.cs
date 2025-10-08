using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;

public sealed record CreateTaskTypeCommand(
    string Name,
    string? Category,
    string? ColorCode,
    string? IconCode,
    string? Description
) : IRequest<CreateTaskTypeCommandResponse>;