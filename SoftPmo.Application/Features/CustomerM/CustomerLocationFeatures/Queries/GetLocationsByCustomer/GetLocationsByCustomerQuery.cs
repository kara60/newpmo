using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetLocationsByCustomer;

public sealed record GetLocationsByCustomerQuery(
    string CustomerId
) : IRequest<IList<CustomerLocation>>;