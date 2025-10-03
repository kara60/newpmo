using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionById;

public sealed record GetPositionByIdQuery(
    string Id
) : IRequest<Position>;