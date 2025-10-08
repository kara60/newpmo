using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;

public sealed record CreateProjectTypeCommand(
    string Name,
    string? Category,
    int? DefaultDurationDays,
    string? ColorCode,
    string? Description
) : IRequest<CreateProjectTypeCommandResponse>;