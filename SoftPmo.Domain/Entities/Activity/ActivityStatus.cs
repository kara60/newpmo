using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Activity;

public class ActivityStatus : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#6B7280";
    public bool IsApproved { get; set; } = false;
    public bool IsRejected { get; set; } = false;
    public bool RequiresApproval { get; set; } = true;
    public int SortOrder { get; set; }

    // Navigation Properties
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
}
