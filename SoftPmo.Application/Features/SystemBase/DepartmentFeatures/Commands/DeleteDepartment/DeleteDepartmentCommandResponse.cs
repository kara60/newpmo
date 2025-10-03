namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.DeleteDepartment;

public sealed record DeleteDepartmentCommandResponse(
    string Message = "Departman başarıyla silindi."
);