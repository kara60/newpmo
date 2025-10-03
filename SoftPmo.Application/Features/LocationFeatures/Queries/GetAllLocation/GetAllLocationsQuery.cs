using MediatR;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Features.LocationFeatures.Queries.GetAllLocations;

public sealed record GetAllLocationsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<Location>>;