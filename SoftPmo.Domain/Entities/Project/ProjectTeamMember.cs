using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectTeamMember : BaseEntity
{
    public string ProjectId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string ProjectRoleId { get; set; } = string.Empty;

    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public DateTime? LeaveDate { get; set; }
    public decimal? AllocationPercentage { get; set; }

    // Navigation Properties
    public virtual ProjectM Project { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual ProjectRole ProjectRole { get; set; } = null!;
}
