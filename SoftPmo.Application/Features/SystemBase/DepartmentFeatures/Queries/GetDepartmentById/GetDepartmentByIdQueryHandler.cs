using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentById;

public sealed class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentByIdQueryHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _departmentService.GetByIdAsync(request.Id, cancellationToken);
        return department;
    }
}