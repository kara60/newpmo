using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateParameterValue;

public sealed class UpdateParameterValueCommandHandler : IRequestHandler<UpdateParameterValueCommand, UpdateParameterValueCommandResponse>
{
    private readonly ISystemParameterService _systemParameterService;

    public UpdateParameterValueCommandHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<UpdateParameterValueCommandResponse> Handle(UpdateParameterValueCommand request, CancellationToken cancellationToken)
    {
        await _systemParameterService.UpdateParameterValueAsync(request.ParameterKey, request.ParameterValue, cancellationToken);
        return new UpdateParameterValueCommandResponse();
    }
}