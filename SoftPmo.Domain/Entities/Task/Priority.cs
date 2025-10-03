using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Task;

public class Priority : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public string ColorCode { get; set; } = "#6B7280";
    public string Icon { get; set; } = "fas fa-exclamation";
    public int DeadlineWarningHours { get; set; } = 24;
    public int SortOrder { get; set; }

    // Navigation Properties
    public virtual ICollection<TaskM> Tasks { get; set; } = new List<TaskM>();
    public virtual ICollection<TaskTodoItem> TodoItems { get; set; } = new List<TaskTodoItem>();
}
