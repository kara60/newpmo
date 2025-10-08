using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetSystemParameterById;

public sealed class GetSystemParameterByIdQueryHandler : IRequestHandler<GetSystemParameterByIdQuery, SystemParameter>
{
    private readonly ISystemParameterService _systemParameterService;

    public GetSystemParameterByIdQueryHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<SystemParameter> Handle(GetSystemParameterByIdQuery request, CancellationToken cancellationToken)
    {
        var systemParameter = await _systemParameterService.GetByIdAsync(request.Id, cancellationToken);
        return systemParameter;
    }
}