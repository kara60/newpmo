namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.MarkAsRead;

public sealed record MarkAsReadCommandResponse(
    string Message = "Bildirim okundu olarak işaretlendi."
);