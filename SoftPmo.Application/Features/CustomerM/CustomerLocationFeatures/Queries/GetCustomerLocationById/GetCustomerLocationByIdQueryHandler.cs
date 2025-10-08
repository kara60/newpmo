using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetCustomerLocationById;

public sealed class GetCustomerLocationByIdQueryHandler : IRequestHandler<GetCustomerLocationByIdQuery, CustomerLocation>
{
    private readonly ICustomerLocationService _customerLocationService;

    public GetCustomerLocationByIdQueryHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<CustomerLocation> Handle(GetCustomerLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var customerLocation = await _customerLocationService.GetByIdAsync(request.Id, cancellationToken);
        return customerLocation;
    }
}