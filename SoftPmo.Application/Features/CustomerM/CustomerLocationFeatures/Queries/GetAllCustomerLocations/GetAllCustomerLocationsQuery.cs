using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetAllCustomerLocations;

public sealed record GetAllCustomerLocationsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? CustomerId = null
) : IRequest<IList<CustomerLocation>>;