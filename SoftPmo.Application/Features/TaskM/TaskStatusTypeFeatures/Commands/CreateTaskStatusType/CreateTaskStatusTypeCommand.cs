using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;

public sealed record CreateTaskStatusTypeCommand(
    string Name,
    string StatusCategory,
    string? Description
) : IRequest<CreateTaskStatusTypeCommandResponse>;