using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;

public sealed record UpdateProjectTypeCommand(
    string Id,
    string Name,
    string? Category,
    int? DefaultDurationDays,
    string? ColorCode,
    string? Description,
    bool IsActive
) : IRequest<UpdateProjectTypeCommandResponse>;