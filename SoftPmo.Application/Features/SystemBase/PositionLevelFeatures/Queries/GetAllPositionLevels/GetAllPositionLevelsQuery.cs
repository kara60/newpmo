using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetAllPositionLevels;

public sealed record GetAllPositionLevelsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null
) : IRequest<IList<PositionLevel>>;