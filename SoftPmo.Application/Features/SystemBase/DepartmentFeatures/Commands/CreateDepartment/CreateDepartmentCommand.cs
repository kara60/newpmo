using MediatR;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;

public sealed record CreateDepartmentCommand(
    string Name,
    string ParentDepartmentId,
    string ManagerId,
    string LocationId,
    string Description
) : IRequest<CreateDepartmentCommandResponse>;