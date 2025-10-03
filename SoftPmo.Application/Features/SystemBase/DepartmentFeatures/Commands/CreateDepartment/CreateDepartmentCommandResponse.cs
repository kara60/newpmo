namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;

public sealed record CreateDepartmentCommandResponse(
    string Id,
    string Code,
    string Message = "Departman başarıyla oluşturuldu."
);