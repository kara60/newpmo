using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.DeleteProjectTeamMember;

public sealed record DeleteProjectTeamMemberCommand(
    string Id
) : IRequest<DeleteProjectTeamMemberCommandResponse>;