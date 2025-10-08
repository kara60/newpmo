namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;

public sealed record CreateNotificationCommandResponse(
    string Id,
    string Message = "Bildirim başarıyla oluşturuldu."
);