using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Notes;

public class NotePageAttachment : BaseEntity
{
    public string NotePageId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string? DisplayName { get; set; }
    public string ContentType { get; set; } = string.Empty;
    public long FileSize { get; set; }
    public string? FilePath { get; set; }
    public string? FileUrl { get; set; }
    public string? ThumbnailUrl { get; set; }
    public string AttachmentType { get; set; } = "File";
    public string? LinkUrl { get; set; }
    public string? LinkTitle { get; set; }
    public string UploadedByUserId { get; set; }
    public DateTime UploadedDate { get; set; } = DateTime.UtcNow;
    public bool IsEmbedded { get; set; } = false;

    // Navigation Properties
    public virtual NotePage NotePage { get; set; } = null!;
    public virtual User UploadedByUser { get; set; } = null!;
}
