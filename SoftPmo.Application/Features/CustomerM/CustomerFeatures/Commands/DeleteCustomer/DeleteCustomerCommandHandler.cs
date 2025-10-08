using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerCommandHandler(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _customerService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteCustomerCommandResponse();
    }
}