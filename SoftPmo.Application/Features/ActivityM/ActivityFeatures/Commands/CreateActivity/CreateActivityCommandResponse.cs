namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;

public sealed record CreateActivityCommandResponse(
    string Id,
    string Code,
    string Message = "Faaliyet başarıyla oluşturuldu."
);