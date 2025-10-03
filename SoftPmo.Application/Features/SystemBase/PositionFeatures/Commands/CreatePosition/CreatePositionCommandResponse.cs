namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;

public sealed record CreatePositionCommandResponse(
    string Id,
    string Code,
    string Message = "Pozisyon başarıyla oluşturuldu."
);