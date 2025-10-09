using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Domain.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Activity;

public class ActivityM : BaseEntity
{
    // Foreign Keys
    public string TaskId { get; set; } = string.Empty;
    public string? TaskStepId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string LocationId { get; set; } = string.Empty;
    public string? CustomerLocationId { get; set; }
    public string? ApprovedByUserId { get; set; }

    // Faaliyet Bilgileri
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int DurationMinutes { get; set; }
    public string? Description { get; set; }

    // Onay Bilgileri
    public bool IsApproved { get; set; } = false;
    public DateTime? ApprovalDate { get; set; }
    public string? ApprovalNote { get; set; }

    // Navigation Properties
    [ForeignKey(nameof(TaskId))]
    public virtual TaskM Task { get; set; } = null!;

    [ForeignKey(nameof(TaskStepId))]
    public virtual TaskStep? TaskStep { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    [ForeignKey(nameof(LocationId))]
    public virtual Location Location { get; set; } = null!;

    [ForeignKey(nameof(CustomerLocationId))]
    public virtual CustomerLocation? CustomerLocation { get; set; }

    [ForeignKey(nameof(ApprovedByUserId))]
    public virtual User? ApprovedByUser { get; set; }
}