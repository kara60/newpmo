using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.SystemBase;
using System.Diagnostics;

namespace SoftPmo.Domain.Entities.Customer;

public class CustomerLocation : BaseEntity
{
    public string CustomerId { get; set; } = string.Empty;  // ✅ string
    public string LocationName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string LocationTypeId { get; set; } = string.Empty;  // ✅ string
    public bool IsDefault { get; set; } = false;

    public virtual CustomerM Customer { get; set; } = null!;
    public virtual LocationType LocationType { get; set; } = null!;
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
}
