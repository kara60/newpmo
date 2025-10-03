using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetAllPositionLevels;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface IPositionLevelService
{
    Task<CreatePositionLevelCommandResponse> CreateAsync(CreatePositionLevelCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdatePositionLevelCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<PositionLevel>> GetAllAsync(GetAllPositionLevelsQuery request, CancellationToken cancellationToken);
    Task<PositionLevel> GetByIdAsync(string id, CancellationToken cancellationToken);
}