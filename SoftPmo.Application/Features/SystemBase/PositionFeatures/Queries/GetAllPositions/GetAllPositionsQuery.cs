using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;

public sealed record GetAllPositionsQuery(
    string? Search = null,
    bool? IsActive = true,
    string? DepartmentId = null,
    string? PositionLevelId = null,
    int PageNumber = 1,
    int PageSize = 100
) : IRequest<IList<Position>>;