using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Task;

public class TaskType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#3B82F6";
    public string Icon { get; set; } = "fas fa-tasks";
    public bool RequiresAnalysis { get; set; } = true;
    public bool RequiresTesting { get; set; } = true;
    public bool RequiresDeployment { get; set; } = false;
    public int DefaultEstimatedDays { get; set; } = 1;

    // Navigation Properties
    public virtual ICollection<TaskM> Tasks { get; set; } = new List<TaskM>();
    public virtual ICollection<TaskTypeStep> TaskTypeSteps { get; set; } = new List<TaskTypeStep>();
}
