using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;

public sealed record CreateProjectRoleCommand(
    string Name,
    string? Description
) : IRequest<CreateProjectRoleCommandResponse>;