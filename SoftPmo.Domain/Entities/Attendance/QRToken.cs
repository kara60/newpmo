using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Domain.Entities.Attendance;

public class QRToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime GeneratedDate { get; set; } = DateTime.UtcNow;
    public DateTime ExpiryDate { get; set; }

    public string LocationId { get; set; } = string.Empty;  // ← string
    public bool IsUsed { get; set; } = false;
    public string? UsedByUserId { get; set; }  // ← string
    public DateTime? UsedDate { get; set; }
    public string TokenType { get; set; } = "Daily";

    public virtual Location Location { get; set; } = null!;
    public virtual User? UsedByUser { get; set; }
}
