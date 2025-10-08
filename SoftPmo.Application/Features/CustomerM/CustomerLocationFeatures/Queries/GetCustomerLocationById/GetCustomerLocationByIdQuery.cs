using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetCustomerLocationById;

public sealed record GetCustomerLocationByIdQuery(
    string Id
) : IRequest<CustomerLocation>;