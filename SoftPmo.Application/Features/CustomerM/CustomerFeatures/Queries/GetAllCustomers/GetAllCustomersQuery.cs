using MediatR;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetAllCustomers;

public sealed record GetAllCustomersQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    bool? HasMaintenanceContract = null
) : IRequest<IList<Domain.Entities.Customer.CustomerM>>;