using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetAllDepartments;

public sealed class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IList<Department>>
{
    private readonly IDepartmentService _departmentService;

    public GetAllDepartmentsQueryHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IList<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var departments = await _departmentService.GetAllAsync(request, cancellationToken);
        return departments;
    }
}