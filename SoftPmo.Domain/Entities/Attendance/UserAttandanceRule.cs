using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Attendance;

public class UserAttendanceRule : BaseEntity
{
    public string UserId { get; set; } = string.Empty;  // ← string
    public string AttendanceRuleId { get; set; } = string.Empty;  // ← string
    public DateTime EffectiveDate { get; set; } = DateTime.Today;
    public DateTime? EndDate { get; set; }
    public bool IsDefault { get; set; } = true;

    public virtual User User { get; set; } = null!;
    public virtual AttendanceRule AttendanceRule { get; set; } = null!;
}
