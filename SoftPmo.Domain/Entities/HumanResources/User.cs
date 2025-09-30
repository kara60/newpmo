using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.Attendance;
using SoftPmo.Domain.Entities.Dashboard;
using SoftPmo.Domain.Entities.Notes;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.Reporting;
using SoftPmo.Domain.Entities.System;
using SoftPmo.Domain.Entities.Task;
using System.Diagnostics;

namespace SoftPmo.Domain.Entities.HumanResources;

public class User : BaseEntity
{
    // ====================================
    // TEMEL BİLGİLER
    // ====================================
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    // Foreign Keys
    public string DepartmentId { get; set; } = string.Empty;
    public string PositionId { get; set; } = string.Empty;
    public string? DirectManagerId { get; set; }
    public decimal BillingMultiplier { get; set; } = 1.0m;

    // ====================================
    // COMPUTED PROPERTIES
    // ====================================
    public string FullName => $"{FirstName} {LastName}";

    // ====================================
    // NAVIGATION PROPERTIES - ORGANİZASYON
    // ====================================
    public virtual Department Department { get; set; } = null!;
    public virtual Position Position { get; set; } = null!;

    // Self-referencing (Yönetici-Çalışan ilişkisi)
    public virtual User? DirectManager { get; set; }
    public virtual ICollection<User> Subordinates { get; set; } = new List<User>();

    // ====================================
    // NAVIGATION PROPERTIES - PROJE
    // ====================================
    public virtual ICollection<ProjectM> ManagedProjects { get; set; } = new List<ProjectM>();
    public virtual ICollection<ProjectTeamMember> ProjectMemberships { get; set; } = new List<ProjectTeamMember>();

    // ====================================
    // NAVIGATION PROPERTIES - TASK
    // ====================================
    public virtual ICollection<TaskM> CreatedTasks { get; set; } = new List<TaskM>();
    public virtual ICollection<TaskM> MainResponsibleTasks { get; set; } = new List<TaskM>();
    public virtual ICollection<TaskStep> AssignedTaskSteps { get; set; } = new List<TaskStep>();

    // ====================================
    // NAVIGATION PROPERTIES - ACTIVITY
    // ====================================
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
    // ApprovedByUser için collection yok (tek yönlü ilişki)

    // ====================================
    // NAVIGATION PROPERTIES - ATTENDANCE
    // ====================================
    public virtual ICollection<AttendanceSession> AttendanceSessions { get; set; } = new List<AttendanceSession>();
    public virtual ICollection<AttendanceException> AttendanceExceptions { get; set; } = new List<AttendanceException>();
    public virtual ICollection<UserAttendanceRule> UserAttendanceRules { get; set; } = new List<UserAttendanceRule>();
    // ApprovedByUser için collection yok (tek yönlü ilişki)

    // ====================================
    // NAVIGATION PROPERTIES - REPORTING
    // ====================================
    public virtual ICollection<DailyAttendanceReport> DailyAttendanceReports { get; set; } = new List<DailyAttendanceReport>();
    public virtual ICollection<AttendanceSummary> AttendanceSummaries { get; set; } = new List<AttendanceSummary>();

    // ====================================
    // NAVIGATION PROPERTIES - DASHBOARD
    // ====================================
    public virtual ICollection<UserDashboardWidget> UserDashboardWidgets { get; set; } = new List<UserDashboardWidget>();

    // ====================================
    // NAVIGATION PROPERTIES - NOTES
    // ====================================
    public virtual ICollection<Notebook> OwnedNotebooks { get; set; } = new List<Notebook>();
    public virtual ICollection<NotePage> CreatedPages { get; set; } = new List<NotePage>();
    public virtual ICollection<NoteTag> CreatedTags { get; set; } = new List<NoteTag>();
    public virtual ICollection<NoteComment> AuthoredComments { get; set; } = new List<NoteComment>();
    public virtual ICollection<NotebookPermission> NotebookPermissions { get; set; } = new List<NotebookPermission>();

    // Tek yönlü ilişkiler için collection yok:
    // - LastModifiedByUser (NotePage)
    // - ResolvedByUser (NoteComment)
    // - GrantedByUser (NotebookPermission)
    // - AddedByUser (NotePageTag)
    // - UploadedByUser (NotePageAttachment)
    // - CompletedByUser (TaskTodoItem)
    // - UsedByUser (QRToken)
}
