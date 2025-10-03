using MediatR;
using SoftPmo.Application.Services.System;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Features.LocationFeatures.Queries.GetLocationById;

public sealed class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, Location>
{
    private readonly ILocationService _locationService;

    public GetLocationByIdQueryHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<Location> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var location = await _locationService.GetByIdAsync(request.Id, cancellationToken);
        return location;
    }
}