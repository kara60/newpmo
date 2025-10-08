using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerWithDetails;

public sealed class GetCustomerWithDetailsQueryHandler : IRequestHandler<GetCustomerWithDetailsQuery, Domain.Entities.Customer.CustomerM>
{
    private readonly ICustomerService _customerService;

    public GetCustomerWithDetailsQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Domain.Entities.Customer.CustomerM> Handle(GetCustomerWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetWithDetailsAsync(request.Id, cancellationToken);
        return customer;
    }
}