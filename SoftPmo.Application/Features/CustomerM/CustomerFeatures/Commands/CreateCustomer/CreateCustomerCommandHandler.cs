using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var response = await _customerService.CreateAsync(request, cancellationToken);
        return response;
    }
}