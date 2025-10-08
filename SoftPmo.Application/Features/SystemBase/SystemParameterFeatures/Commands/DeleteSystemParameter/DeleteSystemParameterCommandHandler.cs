using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.DeleteSystemParameter;

public sealed class DeleteSystemParameterCommandHandler : IRequestHandler<DeleteSystemParameterCommand, DeleteSystemParameterCommandResponse>
{
    private readonly ISystemParameterService _systemParameterService;

    public DeleteSystemParameterCommandHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<DeleteSystemParameterCommandResponse> Handle(DeleteSystemParameterCommand request, CancellationToken cancellationToken)
    {
        await _systemParameterService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteSystemParameterCommandResponse();
    }
}