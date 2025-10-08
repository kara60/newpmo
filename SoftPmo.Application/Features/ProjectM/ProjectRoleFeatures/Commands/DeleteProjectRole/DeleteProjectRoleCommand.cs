using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.DeleteProjectRole;

public sealed record DeleteProjectRoleCommand(
    string Id
) : IRequest<DeleteProjectRoleCommandResponse>;