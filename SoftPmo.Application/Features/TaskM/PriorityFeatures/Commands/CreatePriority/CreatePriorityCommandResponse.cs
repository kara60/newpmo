namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;

public sealed record CreatePriorityCommandResponse(
    string Id,
    string Code,
    string Message = "Öncelik başarıyla oluşturuldu."
);