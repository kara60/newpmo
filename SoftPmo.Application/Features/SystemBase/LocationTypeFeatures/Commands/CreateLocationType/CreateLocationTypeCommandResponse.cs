namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;

public sealed record CreateLocationTypeCommandResponse(
    string Id,
    string Code,
    string Message = "Lokasyon tipi başarıyla oluşturuldu."
);