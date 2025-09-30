using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Dashboard;

public class UserDashboardWidget : BaseEntity
{
    public int UserId { get; set; }
    public int DashboardWidgetId { get; set; }
    public bool IsVisible { get; set; } = true;
    public int SortOrder { get; set; }
    public string Position { get; set; } = "Main";
    public string Size { get; set; } = "Medium";
    public string? CustomTitle { get; set; }
    public string? PersonalConfigurationJson { get; set; }

    // Navigation Properties
    public virtual User User { get; set; } = null!;
    public virtual DashboardWidget DashboardWidget { get; set; } = null!;
}
