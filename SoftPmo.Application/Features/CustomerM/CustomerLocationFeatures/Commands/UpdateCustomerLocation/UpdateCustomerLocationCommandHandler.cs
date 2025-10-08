using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;

public sealed class UpdateCustomerLocationCommandHandler : IRequestHandler<UpdateCustomerLocationCommand, UpdateCustomerLocationCommandResponse>
{
    private readonly ICustomerLocationService _customerLocationService;

    public UpdateCustomerLocationCommandHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<UpdateCustomerLocationCommandResponse> Handle(UpdateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        await _customerLocationService.UpdateAsync(request, cancellationToken);
        return new UpdateCustomerLocationCommandResponse();
    }
}