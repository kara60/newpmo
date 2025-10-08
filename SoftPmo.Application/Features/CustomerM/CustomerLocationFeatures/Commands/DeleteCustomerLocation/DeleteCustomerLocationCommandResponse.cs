namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.DeleteCustomerLocation;

public sealed record DeleteCustomerLocationCommandResponse(
    string Message = "Müşteri lokasyonu başarıyla silindi."
);