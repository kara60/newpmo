using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Queries.GetAllLocation;

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