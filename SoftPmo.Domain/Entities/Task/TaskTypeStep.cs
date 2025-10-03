using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Domain.Entities.Task;

public class TaskTypeStep : BaseEntity
{
    public string TaskTypeId { get; set; } = string.Empty;
    public string StepId { get; set; } = string.Empty;
    public string? DefaultDepartmentId { get; set; }

    // Diğer özellikler
    public int SortOrder { get; set; }
    public bool IsRequired { get; set; } = true;
    public int? DefaultDurationDays { get; set; }

    // Navigation Properties
    public virtual TaskType TaskType { get; set; } = null!;
    public virtual Step Step { get; set; } = null!;
    public virtual Department? DefaultDepartment { get; set; }
}
