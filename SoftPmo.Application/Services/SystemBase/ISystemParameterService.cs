using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetAllSystemParameters;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface ISystemParameterService
{
    Task<CreateSystemParameterCommandResponse> CreateAsync(CreateSystemParameterCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateSystemParameterCommand request, CancellationToken cancellationToken);
    Task UpdateParameterValueAsync(string parameterKey, string parameterValue, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<SystemParameter>> GetAllAsync(GetAllSystemParametersQuery request, CancellationToken cancellationToken);
    Task<SystemParameter> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<SystemParameter> GetByKeyAsync(string parameterKey, CancellationToken cancellationToken);
}