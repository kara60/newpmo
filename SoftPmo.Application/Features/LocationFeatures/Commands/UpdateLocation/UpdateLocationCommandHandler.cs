using MediatR;
using SoftPmo.Application.Services.System;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.UpdateLocation;

public sealed class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, UpdateLocationCommandResponse>
{
    private readonly ILocationService _locationService;

    public UpdateLocationCommandHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        await _locationService.UpdateAsync(request, cancellationToken);
        return new UpdateLocationCommandResponse();
    }
}