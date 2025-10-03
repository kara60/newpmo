using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetLocationTypeById;

public sealed class GetLocationTypeByIdQueryHandler : IRequestHandler<GetLocationTypeByIdQuery, LocationType>
{
    private readonly ILocationTypeService _locationTypeService;

    public GetLocationTypeByIdQueryHandler(ILocationTypeService locationTypeService)
    {
        _locationTypeService = locationTypeService;
    }

    public async Task<LocationType> Handle(GetLocationTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var locationType = await _locationTypeService.GetByIdAsync(request.Id, cancellationToken);
        return locationType;
    }
}