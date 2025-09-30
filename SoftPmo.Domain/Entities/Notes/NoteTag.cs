using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Notes;

public class NoteTag : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string ColorCode { get; set; } = "#10B981";
    public string? Icon { get; set; }
    public int CreatedByUserId { get; set; }
    public bool IsSystemTag { get; set; } = false;
    public bool IsShared { get; set; } = false;
    public int UsageCount { get; set; } = 0;

    // Navigation Properties
    public virtual User CreatedByUser { get; set; } = null!;
    public virtual ICollection<NotePageTag> NotePageTags { get; set; } = new List<NotePageTag>();
}
