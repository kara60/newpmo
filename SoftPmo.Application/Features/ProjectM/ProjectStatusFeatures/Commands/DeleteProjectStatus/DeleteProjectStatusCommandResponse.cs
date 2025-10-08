namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.DeleteProjectStatus;

public sealed record DeleteProjectStatusCommandResponse(
    string Message = "Proje durumu başarıyla silindi."
);