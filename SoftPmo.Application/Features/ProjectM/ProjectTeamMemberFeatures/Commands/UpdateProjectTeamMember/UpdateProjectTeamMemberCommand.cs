using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;

public sealed record UpdateProjectTeamMemberCommand(
    string Id,
    string ProjectId,
    string UserId,
    string ProjectRoleId,
    DateTime JoinedDate,
    DateTime? LeftDate,
    string? Description,
    bool IsActive
) : IRequest<UpdateProjectTeamMemberCommandResponse>;