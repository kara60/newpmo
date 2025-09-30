using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Task;

public class TaskTodoItem : BaseEntity
{
    public string TaskId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }

    public string? AssignedUserId { get; set; }

    public bool IsCompleted { get; set; } = false;
    public DateTime? CompletedDate { get; set; }

    public string? CompletedByUserId { get; set; }  // ← Bu alanı açık belirt

    public int SortOrder { get; set; }
    public string? ParentTodoItemId { get; set; }
    public DateTime? DueDate { get; set; }
    public string PriorityId { get; set; } = string.Empty;

    // Navigation Properties - ForeignKey ile işaretle
    public virtual TaskM Task { get; set; } = null!;

    [ForeignKey(nameof(AssignedUserId))]
    public virtual User? AssignedUser { get; set; }

    [ForeignKey(nameof(CompletedByUserId))]
    public virtual User? CompletedByUser { get; set; }

    public virtual Priority Priority { get; set; } = null!;

    [ForeignKey(nameof(ParentTodoItemId))]
    public virtual TaskTodoItem? ParentTodoItem { get; set; }

    public virtual ICollection<TaskTodoItem> SubTodoItems { get; set; } = new List<TaskTodoItem>();
}
