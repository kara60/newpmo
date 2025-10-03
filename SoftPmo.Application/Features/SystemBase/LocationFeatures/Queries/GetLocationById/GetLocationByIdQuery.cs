using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Queries.GetLocationById;

public sealed record GetLocationByIdQuery(
    string Id
) : IRequest<Location>;