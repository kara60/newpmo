using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetAllCustomers;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Application.Services.CustomerM;

public interface ICustomerService
{
    Task<CreateCustomerCommandResponse> CreateAsync(CreateCustomerCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateCustomerCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Customer.CustomerM>> GetAllAsync(GetAllCustomersQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Customer.CustomerM> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Domain.Entities.Customer.CustomerM> GetWithDetailsAsync(string id, CancellationToken cancellationToken);
}