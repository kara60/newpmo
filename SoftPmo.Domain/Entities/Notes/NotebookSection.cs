using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Notes;

public class NotebookSection : BaseEntity
{
    public int NotebookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string ColorCode { get; set; } = "#6B7280";
    public string Icon { get; set; } = "fas fa-folder";
    public int SortOrder { get; set; }
    public bool IsLocked { get; set; } = false;
    public bool IsArchived { get; set; } = false;
    public int TotalPages { get; set; } = 0;
    public DateTime? LastModified { get; set; }

    // Navigation Properties
    public virtual Notebook Notebook { get; set; } = null!;
    public virtual ICollection<NotePage> Pages { get; set; } = new List<NotePage>();
}
