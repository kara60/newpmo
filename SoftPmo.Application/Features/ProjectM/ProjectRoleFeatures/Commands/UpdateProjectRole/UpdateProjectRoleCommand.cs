using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;

public sealed record UpdateProjectRoleCommand(
    string Id,
    string Name,
    string? Description,
    bool IsActive
) : IRequest<UpdateProjectRoleCommandResponse>;