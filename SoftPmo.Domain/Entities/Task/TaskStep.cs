using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.System;
using System.Diagnostics;

namespace SoftPmo.Domain.Entities.Task;

public class TaskStep : BaseEntity
{
    public string TaskId { get; set; } = string.Empty;
    public string StepId { get; set; } = string.Empty;
    public string AssignedUserId { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public string TaskStatusId { get; set; } = string.Empty;

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int EstimatedDurationDays { get; set; }
    public decimal BillingMultiplier { get; set; } = 1.0m;
    public decimal BillingDurationDays { get; set; }
    public int SortOrder { get; set; }
    public bool IsRequired { get; set; } = true;
    public bool IsCompleted { get; set; } = false;
    public DateTime? CompletedDate { get; set; }
    public string? Dependencies { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public virtual TaskM Task { get; set; } = null!;
    public virtual Step Step { get; set; } = null!;
    public virtual User AssignedUser { get; set; } = null!;
    public virtual Department Department { get; set; } = null!;
    public virtual TaskStatus TaskStatus { get; set; } = null!;
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
}
