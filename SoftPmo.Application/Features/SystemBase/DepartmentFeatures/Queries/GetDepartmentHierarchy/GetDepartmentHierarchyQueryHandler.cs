using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentHierarchy;

public sealed class GetDepartmentHierarchyQueryHandler : IRequestHandler<GetDepartmentHierarchyQuery, IList<Department>>
{
    private readonly IDepartmentService _departmentService;

    public GetDepartmentHierarchyQueryHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<IList<Department>> Handle(GetDepartmentHierarchyQuery request, CancellationToken cancellationToken)
    {
        var hierarchy = await _departmentService.GetHierarchyAsync(cancellationToken);
        return hierarchy;
    }
}