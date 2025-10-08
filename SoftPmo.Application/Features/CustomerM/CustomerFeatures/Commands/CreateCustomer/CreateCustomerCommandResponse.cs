namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;

public sealed record CreateCustomerCommandResponse(
    string Id,
    string Code,
    string Message = "Müşteri başarıyla oluşturuldu."
);