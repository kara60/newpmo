using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.SystemBase;

public class Position : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string DepartmentId { get; set; } = string.Empty;
    public string PositionLevelId { get; set; } = string.Empty;
    public decimal BillingMultiplier { get; set; } = 1.0m;

    // Navigation Properties
    public virtual Department Department { get; set; } = null!;
    public virtual PositionLevel PositionLevel { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
