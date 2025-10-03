using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetAllDepartments;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface IDepartmentService
{
    Task<CreateDepartmentCommandResponse> CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateDepartmentCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Department>> GetAllAsync(GetAllDepartmentsQuery request, CancellationToken cancellationToken);
    Task<Department> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Department>> GetHierarchyAsync(CancellationToken cancellationToken);
}