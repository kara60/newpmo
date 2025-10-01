using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Domain.Entities.Customer;

public class CustomerM : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string TaxNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool HasMaintenanceContract { get; set; } = false;
    public decimal? MonthlyMaintenanceFee { get; set; }
    public DateTime? MaintenanceStartDate { get; set; }
    public DateTime? MaintenanceEndDate { get; set; }
    public bool AutoRenewMaintenance { get; set; } = false;
    public string PrimaryContactName { get; set; } = string.Empty;
    public string PrimaryContactEmail { get; set; } = string.Empty;
    public string TechnicalContactName { get; set; } = string.Empty;
    public string TechnicalContactEmail { get; set; } = string.Empty;

    // Navigation Properties
    public virtual ICollection<CustomerLocation> CustomerLocations { get; set; } = new List<CustomerLocation>();
    public virtual ICollection<ProjectM> Projects { get; set; } = new List<ProjectM>();
    public virtual ICollection<TaskM> Tasks { get; set; } = new List<TaskM>();
}
