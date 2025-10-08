namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.DeleteSystemParameter;

public sealed record DeleteSystemParameterCommandResponse(
    string Message = "Sistem parametresi başarıyla silindi."
);