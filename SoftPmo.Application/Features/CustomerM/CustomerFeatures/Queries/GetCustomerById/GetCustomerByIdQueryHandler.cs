using MediatR;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Domain.Entities.Customer.CustomerM>
{
    private readonly ICustomerService _customerService;

    public GetCustomerByIdQueryHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<Domain.Entities.Customer.CustomerM> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerService.GetByIdAsync(request.Id, cancellationToken);
        return customer;
    }
}