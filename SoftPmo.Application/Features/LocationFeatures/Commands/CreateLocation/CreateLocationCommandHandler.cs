using MediatR;
using SoftPmo.Application.Services.System;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;

public sealed class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationCommandResponse>
{
    private readonly ILocationService _locationService;

    public CreateLocationCommandHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var response = await _locationService.CreateAsync(request, cancellationToken);
        return response;
    }
}
