using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionsByDepartment;

public sealed record GetPositionsByDepartmentQuery(
    string DepartmentId
) : IRequest<IList<Position>>;