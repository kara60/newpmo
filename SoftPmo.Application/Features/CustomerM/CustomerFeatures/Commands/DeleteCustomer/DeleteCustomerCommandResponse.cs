namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommandResponse(
    string Message = "Müşteri başarıyla silindi."
);