using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.DeletePosition;

public sealed class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, DeletePositionCommandResponse>
{
    private readonly IPositionService _positionService;

    public DeletePositionCommandHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<DeletePositionCommandResponse> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
    {
        await _positionService.DeleteAsync(request.Id, cancellationToken);
        return new DeletePositionCommandResponse();
    }
}