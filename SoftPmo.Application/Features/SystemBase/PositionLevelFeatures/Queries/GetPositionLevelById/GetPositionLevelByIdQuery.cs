using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetPositionLevelById;

public sealed record GetPositionLevelByIdQuery(
    string Id
) : IRequest<PositionLevel>;