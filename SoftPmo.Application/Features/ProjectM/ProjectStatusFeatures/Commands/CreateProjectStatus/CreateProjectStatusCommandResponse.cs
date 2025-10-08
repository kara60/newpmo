namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;

public sealed record CreateProjectStatusCommandResponse(
    string Id,
    string Code,
    string Message = "Proje durumu başarıyla oluşturuldu."
);