using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetAllCustomerLocations;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Services.CustomerM;

public interface ICustomerLocationService
{
    Task<CreateCustomerLocationCommandResponse> CreateAsync(CreateCustomerLocationCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateCustomerLocationCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<CustomerLocation>> GetAllAsync(GetAllCustomerLocationsQuery request, CancellationToken cancellationToken);
    Task<CustomerLocation> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<CustomerLocation>> GetByCustomerAsync(string customerId, CancellationToken cancellationToken);
}