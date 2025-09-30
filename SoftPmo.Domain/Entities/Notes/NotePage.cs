using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Domain.Entities.Notes;

public class NotePage : BaseEntity
{
    public string NotebookSectionId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string ContentType { get; set; } = "Markdown";
    public string CreatedByUserId { get; set; }
    public string? LastModifiedByUserId { get; set; }
    public DateTime LastModified { get; set; } = DateTime.UtcNow;
    public int SortOrder { get; set; }
    public bool IsFavorite { get; set; } = false;
    public bool IsPinned { get; set; } = false;
    public bool IsTemplate { get; set; } = false;
    public string? RelatedTaskId { get; set; }
    public string? RelatedProjectId { get; set; }
    public string? RelatedCustomerId { get; set; }
    public string? SearchableContent { get; set; }
    public int ContentWordCount { get; set; } = 0;
    public string? Summary { get; set; }

    // Navigation Properties
    public virtual NotebookSection NotebookSection { get; set; } = null!;
    public virtual User CreatedByUser { get; set; } = null!;
    public virtual User? LastModifiedByUser { get; set; }
    public virtual TaskM? RelatedTask { get; set; }
    public virtual ProjectM? RelatedProject { get; set; }
    public virtual CustomerM? RelatedCustomer { get; set; }
    public virtual ICollection<NotePageTag> NotePageTags { get; set; } = new List<NotePageTag>();
    public virtual ICollection<NotePageAttachment> Attachments { get; set; } = new List<NotePageAttachment>();
    public virtual ICollection<NoteComment> Comments { get; set; } = new List<NoteComment>();
}
