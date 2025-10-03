using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetAllLocationTypes;

public sealed record GetAllLocationTypesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<LocationType>>;