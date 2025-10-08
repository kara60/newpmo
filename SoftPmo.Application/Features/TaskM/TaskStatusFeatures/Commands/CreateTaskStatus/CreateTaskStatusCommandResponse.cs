namespace SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;

public sealed record CreateTaskStatusCommandResponse(
    string Id,
    string Code,
    string Message = "İş durumu başarıyla oluşturuldu."
);