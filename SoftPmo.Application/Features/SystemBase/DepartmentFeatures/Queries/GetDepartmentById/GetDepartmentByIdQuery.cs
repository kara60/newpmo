using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentById;

public sealed record GetDepartmentByIdQuery(
    string Id
) : IRequest<Department>;