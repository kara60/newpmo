namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;

public sealed record CreateTaskCommandResponse(
    string Id,
    string Code,
    string Message = "İş başarıyla oluşturuldu."
);