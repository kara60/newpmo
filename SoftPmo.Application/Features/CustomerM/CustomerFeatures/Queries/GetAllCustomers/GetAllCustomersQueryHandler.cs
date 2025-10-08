using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetAllCustomers;

public sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IList<Domain.Entities.Customer.CustomerM>>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<IList<Domain.Entities.Customer.CustomerM>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerService.GetAllAsync(request, cancellationToken);
        return customers;
    }
}