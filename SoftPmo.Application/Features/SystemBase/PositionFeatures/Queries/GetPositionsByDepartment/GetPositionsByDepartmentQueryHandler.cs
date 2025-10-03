using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionsByDepartment;

public sealed class GetPositionsByDepartmentQueryHandler : IRequestHandler<GetPositionsByDepartmentQuery, IList<Position>>
{
    private readonly IPositionService _positionService;

    public GetPositionsByDepartmentQueryHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<IList<Position>> Handle(GetPositionsByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var positions = await _positionService.GetByDepartmentAsync(request.DepartmentId, cancellationToken);
        return positions;
    }
}