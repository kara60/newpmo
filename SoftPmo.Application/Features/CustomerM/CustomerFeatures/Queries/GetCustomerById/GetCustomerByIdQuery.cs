using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerById;

public sealed record GetCustomerByIdQuery(
    string Id
) : IRequest<Domain.Entities.Customer.CustomerM>;