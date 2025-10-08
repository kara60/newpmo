using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;

public sealed record CreateProjectTeamMemberCommand(
    string ProjectId,
    string UserId,
    string ProjectRoleId,
    DateTime JoinedDate,
    string? Description
) : IRequest<CreateProjectTeamMemberCommandResponse>;