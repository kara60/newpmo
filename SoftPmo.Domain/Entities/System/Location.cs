using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Attendance;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.System;

public class Location : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string LocationTypeId { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public string QRCode { get; set; } = string.Empty;
    public bool IsQREnabled { get; set; } = true;

    // Navigation Properties
    public virtual LocationType LocationType { get; set; } = null!;
    public virtual ICollection<User> Users { get; set; } = new List<User>();
    public virtual ICollection<CustomerLocation> CustomerLocations { get; set; } = new List<CustomerLocation>();
    public virtual ICollection<AttendanceSession> CheckInSessions { get; set; } = new List<AttendanceSession>();
}
