using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.System;

public class LocationType : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string ColorCode { get; set; } = "#6B7280";
    public string Icon { get; set; } = "fas fa-building";
    public bool AllowRemoteWork { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
}
