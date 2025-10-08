namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;

public sealed record CreateCustomerLocationCommandResponse(
    string Id,
    string Code,
    string Message = "Müşteri lokasyonu başarıyla oluşturuldu."
);