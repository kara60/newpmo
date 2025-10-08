namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;

public sealed record CreateProjectCommandResponse(
    string Id,
    string Code,
    string Message = "Proje başarıyla oluşturuldu."
);