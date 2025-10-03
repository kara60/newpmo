namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.DeletePosition;

public sealed record DeletePositionCommandResponse(
    string Message = "Pozisyon başarıyla silindi."
);