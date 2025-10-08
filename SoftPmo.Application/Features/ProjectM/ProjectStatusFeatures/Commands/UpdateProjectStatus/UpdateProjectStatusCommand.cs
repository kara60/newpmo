using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;

public sealed record UpdateProjectStatusCommand(
    string Id,
    string Name,
    string StatusType,
    int SortOrder,
    string? ColorCode,
    string? Description,
    bool IsActive
) : IRequest<UpdateProjectStatusCommandResponse>;