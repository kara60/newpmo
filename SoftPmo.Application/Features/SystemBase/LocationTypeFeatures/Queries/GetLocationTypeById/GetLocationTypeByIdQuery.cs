using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetLocationTypeById;

public sealed record GetLocationTypeByIdQuery(
    string Id
) : IRequest<LocationType>;