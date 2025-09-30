using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Activity;

public class Notification : BaseEntity
{
    public int UserId { get; set; }
    public int NotificationTypeId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    public DateTime? ReadAt { get; set; }
    public int? RelatedEntityId { get; set; }
    public string? RelatedEntityType { get; set; }
    public string? ActionUrl { get; set; }

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual NotificationType NotificationType { get; set; } = null!;
}
