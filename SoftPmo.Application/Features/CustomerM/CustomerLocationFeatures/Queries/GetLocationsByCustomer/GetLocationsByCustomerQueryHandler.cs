using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetLocationsByCustomer;

public sealed class GetLocationsByCustomerQueryHandler : IRequestHandler<GetLocationsByCustomerQuery, IList<CustomerLocation>>
{
    private readonly ICustomerLocationService _customerLocationService;

    public GetLocationsByCustomerQueryHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<IList<CustomerLocation>> Handle(GetLocationsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var customerLocations = await _customerLocationService.GetByCustomerAsync(request.CustomerId, cancellationToken);
        return customerLocations;
    }
}