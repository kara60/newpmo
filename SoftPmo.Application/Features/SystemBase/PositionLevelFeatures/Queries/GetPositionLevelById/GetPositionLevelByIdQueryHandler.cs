using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetPositionLevelById;

public sealed class GetPositionLevelByIdQueryHandler : IRequestHandler<GetPositionLevelByIdQuery, PositionLevel>
{
    private readonly IPositionLevelService _positionLevelService;

    public GetPositionLevelByIdQueryHandler(IPositionLevelService positionLevelService)
    {
        _positionLevelService = positionLevelService;
    }

    public async Task<PositionLevel> Handle(GetPositionLevelByIdQuery request, CancellationToken cancellationToken)
    {
        var positionLevel = await _positionLevelService.GetByIdAsync(request.Id, cancellationToken);
        return positionLevel;
    }
}