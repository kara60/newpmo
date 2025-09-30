using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Task;

public class Step : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#6B7280";
    public string Icon { get; set; } = "fas fa-step-forward";
    public bool CanRunParallel { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<TaskTypeStep> TaskTypeSteps { get; set; } = new List<TaskTypeStep>();
    public virtual ICollection<TaskStep> TaskSteps { get; set; } = new List<TaskStep>();
}
