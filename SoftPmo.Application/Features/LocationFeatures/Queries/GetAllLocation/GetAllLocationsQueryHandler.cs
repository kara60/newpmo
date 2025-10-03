using MediatR;
using SoftPmo.Application.Services.System;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Features.LocationFeatures.Queries.GetAllLocations;

public sealed class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, IList<Location>>
{
    private readonly ILocationService _locationService;

    public GetAllLocationsQueryHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<IList<Location>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        var locations = await _locationService.GetAllAsync(request, cancellationToken);
        return locations;
    }
}