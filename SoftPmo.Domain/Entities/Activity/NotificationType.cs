using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Activity;

public class NotificationType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#3B82F6";
    public string Icon { get; set; } = "fas fa-bell";
    public bool IsSystemGenerated { get; set; } = true;
    public string? MessageTemplate { get; set; }
    public bool SendEmail { get; set; } = false;
    public bool SendPush { get; set; } = true;

    // Navigation Properties
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}
