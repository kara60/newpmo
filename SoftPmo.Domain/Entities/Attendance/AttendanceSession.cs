using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Domain.Entities.Attendance;

public class AttendanceSession : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public string CheckInLocationId { get; set; } = string.Empty;
    public string? CheckOutLocationId { get; set; }

    // Diğer özellikler
    public DateTime SessionDate { get; set; } = DateTime.Today;
    public DateTime CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }
    public string CheckInQRToken { get; set; } = string.Empty;
    public string? CheckOutQRToken { get; set; }

    // ⚠️ BUNLAR INT KALIR - Sayısal değer!
    public int TotalMinutes { get; set; } = 0;

    public bool IsCompleted { get; set; } = false;
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual Location CheckInLocation { get; set; } = null!;
    public virtual Location? CheckOutLocation { get; set; }
}
