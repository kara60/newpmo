using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetAllLocationTypes;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface ILocationTypeService
{
    Task<CreateLocationTypeCommandResponse> CreateAsync(CreateLocationTypeCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateLocationTypeCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<LocationType>> GetAllAsync(GetAllLocationTypesQuery request, CancellationToken cancellationToken);
    Task<LocationType> GetByIdAsync(string id, CancellationToken cancellationToken);
}