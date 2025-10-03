using MediatR;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.DeleteDepartment;

public sealed record DeleteDepartmentCommand(
    string Id
) : IRequest<DeleteDepartmentCommandResponse>;