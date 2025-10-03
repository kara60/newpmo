using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;

public sealed class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, CreatePositionCommandResponse>
{
    private readonly IPositionService _positionService;

    public CreatePositionCommandHandler(IPositionService positionService)
    {
        _positionService = positionService;
    }

    public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        var response = await _positionService.CreateAsync(request, cancellationToken);
        return response;
    }
}