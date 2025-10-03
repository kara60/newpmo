using SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Application.Features.SystemBase.LocationFeatures.Queries.GetAllLocation;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface ILocationService
{
    Task<CreateLocationCommandResponse> CreateAsync(CreateLocationCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateLocationCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Location>> GetAllAsync(GetAllLocationsQuery request, CancellationToken cancellationToken);
    Task<Location> GetByIdAsync(string id, CancellationToken cancellationToken);
}