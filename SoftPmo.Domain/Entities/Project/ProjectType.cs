using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int DefaultDurationDays { get; set; } = 30;
    public string ColorCode { get; set; } = "#10B981";
    public string? DefaultTaskTypes { get; set; }

    // Navigation Properties
    public virtual ICollection<ProjectM> Projects { get; set; } = new List<ProjectM>();
}
