namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.CreateLocation;

public sealed record CreateLocationCommandResponse(
    string Id,
    string Code,
    string Message = "Lokasyon başarıyla oluşturuldu."
);
