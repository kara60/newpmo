using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;

public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.UpdateAsync(request, cancellationToken);
        return new UpdateCustomerCommandResponse();
    }
}