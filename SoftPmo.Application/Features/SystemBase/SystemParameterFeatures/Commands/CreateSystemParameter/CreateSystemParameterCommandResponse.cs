namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;

public sealed record CreateSystemParameterCommandResponse(
    string Id,
    string Code,
    string Message = "Sistem parametresi başarıyla oluşturuldu."
);