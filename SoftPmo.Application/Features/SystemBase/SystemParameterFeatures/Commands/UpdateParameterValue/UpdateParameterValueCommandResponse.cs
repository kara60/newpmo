namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateParameterValue;

public sealed record UpdateParameterValueCommandResponse(
    string Message = "Parametre değeri başarıyla güncellendi."
);