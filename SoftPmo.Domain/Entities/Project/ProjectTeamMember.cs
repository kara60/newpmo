using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectTeamMember : BaseEntity
{
    public int ProjectId { get; set; }
    public int UserId { get; set; }
    public int ProjectRoleId { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public DateTime? LeaveDate { get; set; }
    public decimal? AllocationPercentage { get; set; }

    // Navigation Properties
    public virtual ProjectM Project { get; set; } = null!;
    public virtual User User { get; set; } = null!;
    public virtual ProjectRole ProjectRole { get; set; } = null!;
}
