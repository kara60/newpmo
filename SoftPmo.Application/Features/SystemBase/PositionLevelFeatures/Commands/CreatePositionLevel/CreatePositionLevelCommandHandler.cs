using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;

public sealed class CreatePositionLevelCommandHandler : IRequestHandler<CreatePositionLevelCommand, CreatePositionLevelCommandResponse>
{
    private readonly IPositionLevelService _positionLevelService;

    public CreatePositionLevelCommandHandler(IPositionLevelService positionLevelService)
    {
        _positionLevelService = positionLevelService;
    }

    public async Task<CreatePositionLevelCommandResponse> Handle(CreatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        var response = await _positionLevelService.CreateAsync(request, cancellationToken);
        return response;
    }
}