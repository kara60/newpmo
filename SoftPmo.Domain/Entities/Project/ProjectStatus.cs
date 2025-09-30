using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectStatus : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#3B82F6";
    public bool IsCompleted { get; set; } = false;
    public bool IsCancelled { get; set; } = false;
    public int SortOrder { get; set; }

    // Navigation Properties
    public virtual ICollection<ProjectM> Projects { get; set; } = new List<ProjectM>();
}
