using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;

public sealed class CreateSystemParameterCommandHandler : IRequestHandler<CreateSystemParameterCommand, CreateSystemParameterCommandResponse>
{
    private readonly ISystemParameterService _systemParameterService;

    public CreateSystemParameterCommandHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<CreateSystemParameterCommandResponse> Handle(CreateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        var response = await _systemParameterService.CreateAsync(request, cancellationToken);
        return response;
    }
}