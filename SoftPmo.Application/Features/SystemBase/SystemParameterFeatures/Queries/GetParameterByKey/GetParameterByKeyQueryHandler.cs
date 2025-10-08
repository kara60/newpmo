using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetParameterByKey;

public sealed class GetParameterByKeyQueryHandler : IRequestHandler<GetParameterByKeyQuery, SystemParameter>
{
    private readonly ISystemParameterService _systemParameterService;

    public GetParameterByKeyQueryHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<SystemParameter> Handle(GetParameterByKeyQuery request, CancellationToken cancellationToken)
    {
        var systemParameter = await _systemParameterService.GetByKeyAsync(request.ParameterKey, cancellationToken);
        return systemParameter;
    }
}