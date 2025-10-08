namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;

public sealed record CreateStepCommandResponse(
    string Id,
    string Code,
    string Message = "İş adımı başarıyla oluşturuldu."
);