using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Reporting;

public class DailyAttendanceReport : BaseEntity
{
    public DateTime ReportDate { get; set; } = DateTime.Today;
    public string UserId { get; set; } = string.Empty;  // ← string
    public string UserFullName { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string PositionName { get; set; } = string.Empty;

    public DateTime? CheckInTime { get; set; }
    public DateTime? CheckOutTime { get; set; }

    // BUNLAR INT KALIR
    public int WorkedMinutes { get; set; } = 0;
    public int RequiredMinutes { get; set; } = 480;
    public int OvertimeMinutes { get; set; } = 0;
    public int UndertimeMinutes { get; set; } = 0;
    public int LateMinutes { get; set; } = 0;
    public int EarlyLeaveMinutes { get; set; } = 0;

    public string AttendanceStatus { get; set; } = "Absent";
    public string? ExceptionReason { get; set; }
    public bool IsLate { get; set; } = false;
    public bool IsEarlyLeave { get; set; } = false;
    public string? CheckInLocationName { get; set; }
    public string? CheckOutLocationName { get; set; }

    public virtual User User { get; set; } = null!;
}
