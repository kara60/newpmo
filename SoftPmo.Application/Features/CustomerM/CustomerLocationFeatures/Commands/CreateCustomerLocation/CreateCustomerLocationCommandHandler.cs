using MediatR;
using SoftPmo.Application.Services.CustomerM;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;

public sealed class CreateCustomerLocationCommandHandler : IRequestHandler<CreateCustomerLocationCommand, CreateCustomerLocationCommandResponse>
{
    private readonly ICustomerLocationService _customerLocationService;

    public CreateCustomerLocationCommandHandler(ICustomerLocationService customerLocationService)
    {
        _customerLocationService = customerLocationService;
    }

    public async Task<CreateCustomerLocationCommandResponse> Handle(CreateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        var response = await _customerLocationService.CreateAsync(request, cancellationToken);
        return response;
    }
}