using SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Application.Features.LocationFeatures.Queries.GetAllLocations;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Services.System;

public interface ILocationService
{
    Task<CreateLocationCommandResponse> CreateAsync(CreateLocationCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateLocationCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Location>> GetAllAsync(GetAllLocationsQuery request, CancellationToken cancellationToken);
    Task<Location> GetByIdAsync(string id, CancellationToken cancellationToken);
}