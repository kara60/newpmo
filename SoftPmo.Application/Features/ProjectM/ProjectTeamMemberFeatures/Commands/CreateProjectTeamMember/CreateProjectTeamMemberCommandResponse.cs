namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;

public sealed record CreateProjectTeamMemberCommandResponse(
    string Id,
    string Code,
    string Message = "Ekip üyesi başarıyla eklendi."
);