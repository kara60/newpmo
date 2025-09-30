using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Notes;
using SoftPmo.Domain.Entities.Project;
using System.Diagnostics;

namespace SoftPmo.Domain.Entities.Task;

public class TaskM : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    // ❌ YANLIŞ
    // public int CustomerId { get; set; }
    // public int ProjectId { get; set; }

    // ✅ DOĞRU - HEPSİ STRING!
    public string CustomerId { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public string TaskTypeId { get; set; } = string.Empty;
    public string CreatedByUserId { get; set; } = string.Empty;
    public string? MainResponsibleUserId { get; set; }
    public string TaskStatusId { get; set; } = string.Empty;
    public string PriorityId { get; set; } = string.Empty;

    // Tarihler ve sayısal değerler normal
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime DeadlineDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int TotalEstimatedDays { get; set; }
    public decimal TotalBillingDays { get; set; }

    // Navigation Properties
    public virtual CustomerM Customer { get; set; } = null!;
    public virtual ProjectM Project { get; set; } = null!;
    public virtual TaskType TaskType { get; set; } = null!;
    public virtual User CreatedByUser { get; set; } = null!;
    public virtual User? MainResponsibleUser { get; set; }
    public virtual TaskStatus TaskStatus { get; set; } = null!;
    public virtual Priority Priority { get; set; } = null!;
    public virtual ICollection<TaskStep> TaskSteps { get; set; } = new List<TaskStep>();
    public virtual ICollection<TaskTodoItem> TodoItems { get; set; } = new List<TaskTodoItem>();
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
    public virtual ICollection<NotePage> RelatedNotePages { get; set; } = new List<NotePage>();
}
