using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.DeleteCustomerLocation;

public sealed class DeleteCustomerLocationCommandHandler : IRequestHandler<DeleteCustomerLocationCommand, DeleteCustomerLocationCommandResponse>
{
    private readonly ICustomerLocationService _customerLocationService;

    public DeleteCustomerLocationCommandHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<DeleteCustomerLocationCommandResponse> Handle(DeleteCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        await _customerLocationService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteCustomerLocationCommandResponse();
    }
}