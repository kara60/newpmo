using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;

public sealed class UpdateSystemParameterCommandHandler : IRequestHandler<UpdateSystemParameterCommand, UpdateSystemParameterCommandResponse>
{
    private readonly ISystemParameterService _systemParameterService;

    public UpdateSystemParameterCommandHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<UpdateSystemParameterCommandResponse> Handle(UpdateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        await _systemParameterService.UpdateAsync(request, cancellationToken);
        return new UpdateSystemParameterCommandResponse();
    }
}