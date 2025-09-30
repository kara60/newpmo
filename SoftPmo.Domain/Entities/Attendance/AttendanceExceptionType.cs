using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Attendance;

public class AttendanceExceptionType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#F59E0B";
    public string Icon { get; set; } = "fas fa-calendar-times";
    public bool RequiresApproval { get; set; } = true;
    public bool IsDeductible { get; set; } = true;
    public int DefaultMinutes { get; set; } = 480;

    // Navigation Properties
    public virtual ICollection<AttendanceException> AttendanceExceptions { get; set; } = new List<AttendanceException>();
}
