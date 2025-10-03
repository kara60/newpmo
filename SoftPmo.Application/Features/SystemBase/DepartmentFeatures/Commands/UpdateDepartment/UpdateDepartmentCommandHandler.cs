using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;

public sealed class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdateDepartmentCommandResponse>
{
    private readonly IDepartmentService _departmentService;

    public UpdateDepartmentCommandHandler(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    public async Task<UpdateDepartmentCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        await _departmentService.UpdateAsync(request, cancellationToken);
        return new UpdateDepartmentCommandResponse();
    }
}