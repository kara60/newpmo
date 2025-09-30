using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Reporting;

public class LiveAttendanceStatus : BaseEntity
{
    public string UserId { get; set; } = string.Empty;  // ← string
    public string UserFullName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string PositionName { get; set; } = string.Empty;
    public string? ProfilePhotoUrl { get; set; }

    public bool IsCurrentlyIn { get; set; } = false;
    public DateTime? LastCheckInTime { get; set; }
    public string? CurrentLocationName { get; set; }
    public TimeSpan? CurrentSessionDuration { get; set; }

    // BUNLAR INT KALIR
    public int TodayTotalMinutes { get; set; } = 0;
    public int LateMinutesToday { get; set; } = 0;

    public DateTime? TodayFirstCheckIn { get; set; }
    public DateTime? TodayLastCheckOut { get; set; }
    public string TodayStatus { get; set; } = "Not Arrived";
    public bool IsLateToday { get; set; } = false;
    public string? LastActivityDescription { get; set; }
    public string StatusColor { get; set; } = "#6B7280";

    public virtual User User { get; set; } = null!;
}
