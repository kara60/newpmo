using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetAllUsers;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Services.HumanResources;

public interface IUserService
{
    Task<CreateUserCommandResponse> CreateAsync(CreateUserCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<User>> GetAllAsync(GetAllUsersQuery request, CancellationToken cancellationToken);
    Task<User> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<User>> GetByDepartmentAsync(string departmentId, CancellationToken cancellationToken);
    Task<User> GetWithDetailsAsync(string id, CancellationToken cancellationToken);
}