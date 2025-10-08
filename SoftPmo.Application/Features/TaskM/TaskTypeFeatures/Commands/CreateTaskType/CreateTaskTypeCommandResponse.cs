namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;

public sealed record CreateTaskTypeCommandResponse(
    string Id,
    string Code,
    string Message = "İş tipi başarıyla oluşturuldu."
);