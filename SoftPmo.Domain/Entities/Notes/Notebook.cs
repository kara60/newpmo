using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Domain.Entities.Notes;

public class Notebook : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int OwnerId { get; set; }
    public string ColorCode { get; set; } = "#3B82F6";
    public string Icon { get; set; } = "fas fa-book";
    public int SortOrder { get; set; }
    public bool IsShared { get; set; } = false;
    public bool IsTeamNotebook { get; set; } = false;
    public int? RelatedProjectId { get; set; }
    public int? RelatedCustomerId { get; set; }
    public int TotalSections { get; set; } = 0;
    public int TotalPages { get; set; } = 0;
    public DateTime? LastModified { get; set; }

    // Navigation Properties
    public virtual User Owner { get; set; } = null!;
    public virtual ProjectM? RelatedProject { get; set; }
    public virtual CustomerM? RelatedCustomer { get; set; }
    public virtual ICollection<NotebookSection> Sections { get; set; } = new List<NotebookSection>();
    public virtual ICollection<NotebookPermission> Permissions { get; set; } = new List<NotebookPermission>();
}
