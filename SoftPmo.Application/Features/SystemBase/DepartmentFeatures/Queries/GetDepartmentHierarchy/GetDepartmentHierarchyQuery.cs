using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentHierarchy;

public sealed record GetDepartmentHierarchyQuery() : IRequest<IList<Department>>;