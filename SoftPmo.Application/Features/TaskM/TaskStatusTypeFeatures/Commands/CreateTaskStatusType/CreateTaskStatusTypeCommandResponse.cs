namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;

public sealed record CreateTaskStatusTypeCommandResponse(
    string Id,
    string Code,
    string Message = "İş durumu tipi başarıyla oluşturuldu."
);