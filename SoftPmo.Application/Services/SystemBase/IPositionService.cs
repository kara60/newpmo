using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface IPositionService
{
    Task<CreatePositionCommandResponse> CreateAsync(CreatePositionCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdatePositionCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Position>> GetAllAsync(GetAllPositionsQuery request, CancellationToken cancellationToken);
    Task<Position> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Position>> GetByDepartmentAsync(string departmentId, CancellationToken cancellationToken);
}