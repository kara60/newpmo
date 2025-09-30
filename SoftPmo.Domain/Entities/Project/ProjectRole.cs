using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectRole : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#6B7280";
    public bool CanAssignTasks { get; set; } = false;
    public bool CanApproveActivities { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<ProjectTeamMember> ProjectTeamMembers { get; set; } = new List<ProjectTeamMember>();
}
