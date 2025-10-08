namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.DeleteNotification;

public sealed record DeleteNotificationCommandResponse(
    string Message = "Bildirim başarıyla silindi."
);