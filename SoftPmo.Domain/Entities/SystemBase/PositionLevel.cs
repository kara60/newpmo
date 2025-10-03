using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.SystemBase;

public class PositionLevel : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public decimal DefaultBillingMultiplier { get; set; } = 1.0m;
    public string ColorCode { get; set; } = "#10B981";

    // Navigation Properties
    public virtual ICollection<Position> Positions { get; set; } = new List<Position>();
}
