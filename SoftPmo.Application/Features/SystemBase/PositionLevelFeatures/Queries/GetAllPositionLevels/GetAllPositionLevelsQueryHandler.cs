using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetAllPositionLevels;

public sealed class GetAllPositionLevelsQueryHandler : IRequestHandler<GetAllPositionLevelsQuery, IList<PositionLevel>>
{
    private readonly IPositionLevelService _positionLevelService;

    public GetAllPositionLevelsQueryHandler(IPositionLevelService positionLevelService)
    {
        _positionLevelService = positionLevelService;
    }

    public async Task<IList<PositionLevel>> Handle(GetAllPositionLevelsQuery request, CancellationToken cancellationToken)
    {
        var positionLevels = await _positionLevelService.GetAllAsync(request, cancellationToken);
        return positionLevels;
    }
}