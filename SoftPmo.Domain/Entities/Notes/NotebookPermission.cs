using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Notes;

public class NotebookPermission : BaseEntity
{
    public string NotebookId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string PermissionTypeId { get; set; } = string.Empty;

    public bool CanRead { get; set; } = true;
    public bool CanWrite { get; set; } = false;
    public bool CanDelete { get; set; } = false;
    public bool CanShare { get; set; } = false;
    public bool CanAdmin { get; set; } = false;

    public string GrantedByUserId { get; set; } = string.Empty;  // ← Bu alanı açık belirt
    public DateTime GrantedDate { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiryDate { get; set; }

    // Navigation Properties - ForeignKey ile işaretle
    public virtual Notebook Notebook { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;

    public virtual NotePermissionType PermissionType { get; set; } = null!;

    [ForeignKey(nameof(GrantedByUserId))]
    public virtual User GrantedByUser { get; set; } = null!;
}
