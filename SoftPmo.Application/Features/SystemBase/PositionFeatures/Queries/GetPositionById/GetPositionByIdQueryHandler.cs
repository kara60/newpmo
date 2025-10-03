using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionById;

public sealed class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, Position>
{
    private readonly IPositionService _positionService;

    public GetPositionByIdQueryHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<Position> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
    {
        var position = await _positionService.GetByIdAsync(request.Id, cancellationToken);
        return position;
    }
}