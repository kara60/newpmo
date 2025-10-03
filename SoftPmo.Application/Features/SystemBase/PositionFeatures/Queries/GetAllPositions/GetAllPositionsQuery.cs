using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;

public sealed record GetAllPositionsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string DepartmentId = null,
    string PositionLevelId = null
) : IRequest<IList<Position>>;