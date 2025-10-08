using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetAllSystemParameters;

public sealed class GetAllSystemParametersQueryHandler : IRequestHandler<GetAllSystemParametersQuery, IList<SystemParameter>>
{
    private readonly ISystemParameterService _systemParameterService;

    public GetAllSystemParametersQueryHandler(ISystemParameterService systemParameterService)
    {
        _systemParameterService = systemParameterService;
    }

    public async Task<IList<SystemParameter>> Handle(GetAllSystemParametersQuery request, CancellationToken cancellationToken)
    {
        var systemParameters = await _systemParameterService.GetAllAsync(request, cancellationToken);
        return systemParameters;
    }
}