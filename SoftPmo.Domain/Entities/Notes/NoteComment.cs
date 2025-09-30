using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftPmo.Domain.Entities.Notes;

public class NoteComment : BaseEntity
{
    public string NotePageId { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? ParentCommentId { get; set; }

    public bool IsResolved { get; set; } = false;
    public string? ResolvedByUserId { get; set; }  // ← Bu alanı açık belirt
    public DateTime? ResolvedDate { get; set; }

    public string? AnchorText { get; set; }
    public int? CharacterPosition { get; set; }

    // Navigation Properties - ForeignKey ile işaretle
    public virtual NotePage NotePage { get; set; } = null!;

    [ForeignKey(nameof(AuthorId))]
    public virtual User Author { get; set; } = null!;

    [ForeignKey(nameof(ParentCommentId))]
    public virtual NoteComment? ParentComment { get; set; }

    public virtual ICollection<NoteComment> Replies { get; set; } = new List<NoteComment>();

    [ForeignKey(nameof(ResolvedByUserId))]
    public virtual User? ResolvedByUser { get; set; }
}
