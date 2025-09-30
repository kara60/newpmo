using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Notes;

public class NotePermissionType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string ColorCode { get; set; } = "#6B7280";
    public bool DefaultCanRead { get; set; } = true;
    public bool DefaultCanWrite { get; set; } = false;
    public bool DefaultCanDelete { get; set; } = false;
    public bool DefaultCanShare { get; set; } = false;
    public bool DefaultCanAdmin { get; set; } = false;
    public int SortOrder { get; set; }

    // Navigation Properties
    public virtual ICollection<NotebookPermission> NotebookPermissions { get; set; } = new List<NotebookPermission>();
}
