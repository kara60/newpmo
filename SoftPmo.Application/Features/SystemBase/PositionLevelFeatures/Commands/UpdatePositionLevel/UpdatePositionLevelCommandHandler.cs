using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;

public sealed class UpdatePositionLevelCommandHandler : IRequestHandler<UpdatePositionLevelCommand, UpdatePositionLevelCommandResponse>
{
    private readonly IPositionLevelService _positionLevelService;

    public UpdatePositionLevelCommandHandler(IPositionLevelService positionLevelService)
    {
        _positionLevelService = positionLevelService;
    }

    public async Task<UpdatePositionLevelCommandResponse> Handle(UpdatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        await _positionLevelService.UpdateAsync(request, cancellationToken);
        return new UpdatePositionLevelCommandResponse();
    }
}