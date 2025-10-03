using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Domain.Entities.Task;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Activity;

public class ActivityM : BaseEntity
{
    // Foreign Key'ler - HEPSİNİ AÇIKÇA BELİRT
    public string TaskId { get; set; } = string.Empty;
    public string? TaskStepId { get; set; }
    public string UserId { get; set; } = string.Empty;  // ← Ana kullanıcı
    public string LocationId { get; set; } = string.Empty;
    public string? CustomerLocationId { get; set; }
    public string ActivityStatusId { get; set; } = string.Empty;
    public string? ApprovedByUserId { get; set; }  // ← Onaylayan kullanıcı (İKİNCİ USER İLİŞKİSİ)

    // Diğer özellikler
    public DateTime ActivityDate { get; set; } = DateTime.Today;
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int TotalMinutes { get; set; }
    public string? ApprovalNotes { get; set; }
    public DateTime? ApprovalDate { get; set; }

    // Navigation Properties - [ForeignKey] ile işaretle
    public virtual TaskM Task { get; set; } = null!;
    public virtual TaskStep? TaskStep { get; set; }

    [ForeignKey(nameof(UserId))]  // ← Bu User için UserId kullan
    public virtual User User { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
    public virtual CustomerLocation? CustomerLocation { get; set; }
    public virtual ActivityStatus ActivityStatus { get; set; } = null!;

    [ForeignKey(nameof(ApprovedByUserId))]  // ← Bu User için ApprovedByUserId kullan
    public virtual User? ApprovedByUser { get; set; }
}
