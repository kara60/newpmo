using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.DeleteDepartment;

public sealed class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeleteDepartmentCommandResponse>
{
    private readonly IDepartmentService _departmentService;

    public DeleteDepartmentCommandHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<DeleteDepartmentCommandResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        await _departmentService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteDepartmentCommandResponse();
    }
}