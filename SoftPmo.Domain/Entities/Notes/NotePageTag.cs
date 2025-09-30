using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Notes;

public class NotePageTag : BaseEntity
{
    public string NotePageId { get; set; }
    public string NoteTagId { get; set; }
    public string AddedByUserId { get; set; }
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;

    // Navigation Properties
    public virtual NotePage NotePage { get; set; } = null!;
    public virtual NoteTag NoteTag { get; set; } = null!;
    public virtual User AddedByUser { get; set; } = null!;
}
