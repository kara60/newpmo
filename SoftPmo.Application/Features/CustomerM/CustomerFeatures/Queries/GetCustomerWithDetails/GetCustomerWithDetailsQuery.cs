using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerWithDetails;

public sealed record GetCustomerWithDetailsQuery(
    string Id
) : IRequest<Domain.Entities.Customer.CustomerM>;