using MediatR;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;

public sealed record UpdateDepartmentCommand(
    string Id,
    string Name,
    string ParentDepartmentId,
    string ManagerId,
    string LocationId,
    string Description,
    bool IsActive
) : IRequest<UpdateDepartmentCommandResponse>;