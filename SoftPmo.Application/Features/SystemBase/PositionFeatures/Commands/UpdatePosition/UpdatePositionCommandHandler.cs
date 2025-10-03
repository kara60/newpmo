using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;

public sealed class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, UpdatePositionCommandResponse>
{
    private readonly IPositionService _positionService;

    public UpdatePositionCommandHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<UpdatePositionCommandResponse> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        await _positionService.UpdateAsync(request, cancellationToken);
        return new UpdatePositionCommandResponse();
    }
}