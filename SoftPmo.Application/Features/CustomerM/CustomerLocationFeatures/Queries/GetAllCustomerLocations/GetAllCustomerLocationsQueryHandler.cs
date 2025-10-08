using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetAllCustomerLocations;

public sealed class GetAllCustomerLocationsQueryHandler : IRequestHandler<GetAllCustomerLocationsQuery, IList<CustomerLocation>>
{
    private readonly ICustomerLocationService _customerLocationService;

    public GetAllCustomerLocationsQueryHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<IList<CustomerLocation>> Handle(GetAllCustomerLocationsQuery request, CancellationToken cancellationToken)
    {
        var customerLocations = await _customerLocationService.GetAllAsync(request, cancellationToken);
        return customerLocations;
    }
}