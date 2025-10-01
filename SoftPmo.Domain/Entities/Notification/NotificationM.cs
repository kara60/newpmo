using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Notification;

public class NotificationM : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string NotificationType { get; set; } = string.Empty; // TaskAssigned, DeadlineWarning, StatusChanged
    public bool IsRead { get; set; } = false;
    public DateTime? ReadDate { get; set; }
    public string? RelatedEntityId { get; set; } // Task ID, Project ID vb.

    // Navigation
    public virtual User User { get; set; } = null!;
}
