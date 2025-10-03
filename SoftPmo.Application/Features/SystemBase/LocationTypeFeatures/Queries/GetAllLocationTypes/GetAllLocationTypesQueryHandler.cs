using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetAllLocationTypes;

public sealed class GetAllLocationTypesQueryHandler : IRequestHandler<GetAllLocationTypesQuery, IList<LocationType>>
{
    private readonly ILocationTypeService _locationTypeService;

    public GetAllLocationTypesQueryHandler(ILocationTypeService locationTypeService)
    {
        _locationTypeService = locationTypeService;
    }

    public async Task<IList<LocationType>> Handle(GetAllLocationTypesQuery request, CancellationToken cancellationToken)
    {
        var locationTypes = await _locationTypeService.GetAllAsync(request, cancellationToken);
        return locationTypes;
    }
}