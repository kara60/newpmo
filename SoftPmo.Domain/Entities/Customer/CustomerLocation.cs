using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Domain.Entities.System;
using System.Diagnostics;

namespace SoftPmo.Domain.Entities.Customer;

public class CustomerLocation : BaseEntity
{
    public int CustomerId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public int LocationTypeId { get; set; }
    public bool IsDefault { get; set; } = false;

    // Navigation Properties
    public virtual CustomerM Customer { get; set; } = null!;
    public virtual LocationType LocationType { get; set; } = null!;
    public virtual ICollection<ActivityM> Activities { get; set; } = new List<ActivityM>();
}
