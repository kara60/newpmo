using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(
    string Id
) : IRequest<DeleteCustomerCommandResponse>;