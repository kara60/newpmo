using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Attendance;

public class AttendanceException : BaseEntity
{
    public string UserId { get; set; } = string.Empty;  // ← string
    public DateTime ExceptionDate { get; set; }
    public string AttendanceExceptionTypeId { get; set; } = string.Empty;  // ← string
    public string Reason { get; set; } = string.Empty;
    public string? ApprovedByUserId { get; set; }  // ← string
    public DateTime? ApprovalDate { get; set; }
    public bool IsApproved { get; set; } = false;
    public int? MinutesToDeduct { get; set; }  // ← int kalır

    public virtual User User { get; set; } = null!;
    public virtual AttendanceExceptionType AttendanceExceptionType { get; set; } = null!;
    public virtual User? ApprovedByUser { get; set; }
}
