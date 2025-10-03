using MediatR;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Features.LocationFeatures.Queries.GetLocationById;

public sealed record GetLocationByIdQuery(
    string Id
) : IRequest<Location>;