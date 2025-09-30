using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Attendance;

public class AttendanceRule : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public TimeSpan StartTime { get; set; } = TimeSpan.FromHours(9);
    public TimeSpan EndTime { get; set; } = TimeSpan.FromHours(18);
    public int RequiredMinutes { get; set; } = 480;
    public int FlexibilityMinutes { get; set; } = 30;
    public bool RequiresBothCheckInOut { get; set; } = true;
    public int MaxSessionHours { get; set; } = 12;
    public bool IsDefault { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<UserAttendanceRule> UserAttendanceRules { get; set; } = new List<UserAttendanceRule>();
}
