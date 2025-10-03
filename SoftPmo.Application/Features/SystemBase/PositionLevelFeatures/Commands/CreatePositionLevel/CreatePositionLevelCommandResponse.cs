namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;

public sealed record CreatePositionLevelCommandResponse(
    string Id,
    string Code,
    string Message = "Pozisyon seviyesi başarıyla oluşturuldu."
);