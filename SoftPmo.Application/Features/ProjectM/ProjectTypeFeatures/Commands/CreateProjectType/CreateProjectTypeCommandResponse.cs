namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;

public sealed record CreateProjectTypeCommandResponse(
    string Id,
    string Code,
    string Message = "Proje tipi başarıyla oluşturuldu."
);