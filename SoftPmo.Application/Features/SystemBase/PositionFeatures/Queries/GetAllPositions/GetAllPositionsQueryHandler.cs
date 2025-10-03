using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;

public sealed class GetAllPositionsQueryHandler : IRequestHandler<GetAllPositionsQuery, IList<Position>>
{
    private readonly IPositionService _positionService;

    public GetAllPositionsQueryHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<IList<Position>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
    {
        var positions = await _positionService.GetAllAsync(request, cancellationToken);
        return positions;
    }
}