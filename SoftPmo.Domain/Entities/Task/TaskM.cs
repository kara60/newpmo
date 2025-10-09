using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Domain.Entities.Task;

public class TaskM : BaseEntity
{
    // Temel Bilgiler
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Foreign Keys
    public string CustomerId { get; set; } = string.Empty;
    public string ProjectId { get; set; } = string.Empty;
    public string TaskTypeId { get; set; } = string.Empty;
    public string? MainResponsibleUserId { get; set; }
    public string? DepartmentId { get; set; }
    public string TaskStatusId { get; set; } = string.Empty;
    public string? PriorityId { get; set; }

    // Tarihler ve Sayısal Değerler
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime DueDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public int EstimatedDurationDays { get; set; }
    public decimal BillingMultiplier { get; set; } = 1.0m;
    public decimal BillingDuration { get; set; }

    // Navigation Properties
    public virtual CustomerM Customer { get; set; } = null!;
    public virtual ProjectM Project { get; set; } = null!;
    public virtual TaskType TaskType { get; set; } = null!;
    public virtual User? MainResponsibleUser { get; set; }
    public virtual Department? Department { get; set; }
    public virtual TaskStatus TaskStatus { get; set; } = null!;
    public virtual Priority? Priority { get; set; }
    public virtual ICollection<TaskStep> TaskSteps { get; set; } = new List<TaskStep>();
    public virtual ICollection<TaskTodoItem> TodoItems { get; set; } = new List<TaskTodoItem>();
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
}