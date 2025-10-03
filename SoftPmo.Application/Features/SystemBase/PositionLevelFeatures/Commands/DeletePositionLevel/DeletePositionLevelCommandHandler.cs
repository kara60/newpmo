using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.DeletePositionLevel;

public sealed class DeletePositionLevelCommandHandler : IRequestHandler<DeletePositionLevelCommand, DeletePositionLevelCommandResponse>
{
    private readonly IPositionLevelService _positionLevelService;

    public DeletePositionLevelCommandHandler(IPositionLevelService positionLevelService)
    {
        _positionLevelService = positionLevelService;
    }

    public async Task<DeletePositionLevelCommandResponse> Handle(DeletePositionLevelCommand request, CancellationToken cancellationToken)
    {
        await _positionLevelService.DeleteAsync(request.Id, cancellationToken);
        return new DeletePositionLevelCommandResponse();
    }
}