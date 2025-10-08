namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;

public sealed record CreateProjectRoleCommandResponse(
    string Id,
    string Code,
    string Message = "Proje rolü başarıyla oluşturuldu."
);