using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Notes;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Domain.Entities.Project;

public class ProjectM : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int CustomerId { get; set; }
    public int ProjectTypeId { get; set; }
    public int ProjectManagerId { get; set; }
    public int ProjectStatusId { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime PlannedEndDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public int EstimatedDurationDays { get; set; }
    public int PriorityId { get; set; }

    // Navigation Properties
    public virtual CustomerM Customer { get; set; } = null!;
    public virtual ProjectType ProjectType { get; set; } = null!;
    public virtual User ProjectManager { get; set; } = null!;
    public virtual ProjectStatus ProjectStatus { get; set; } = null!;
    public virtual Priority Priority { get; set; } = null!;
    public virtual ICollection<ProjectTeamMember> TeamMembers { get; set; } = new List<ProjectTeamMember>();
    public virtual ICollection<TaskM> Tasks { get; set; } = new List<TaskM>();
    public virtual ICollection<Notebook> RelatedNotebooks { get; set; } = new List<Notebook>();
}
