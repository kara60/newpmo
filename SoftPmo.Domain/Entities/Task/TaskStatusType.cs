using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Task;

public class TaskStatusType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#6B7280";
    public bool IsCompleted { get; set; } = false;
    public bool IsCancelled { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<TaskStatus> TaskStatuses { get; set; } = new List<TaskStatus>();
}
