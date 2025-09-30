using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Task;

public class TaskStatus : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int TaskStatusTypeId { get; set; }
    public string ColorCode { get; set; } = "#6B7280";
    public int SortOrder { get; set; }
    public bool IsSystemStatus { get; set; } = false;

    // Navigation Properties
    public virtual TaskStatusType TaskStatusType { get; set; } = null!;
    public virtual ICollection<TaskM> Tasks { get; set; } = new List<TaskM>();
    public virtual ICollection<TaskStep> TaskSteps { get; set; } = new List<TaskStep>();
}
