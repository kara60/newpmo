using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.Dashboard;

public class DashboardWidget : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string WidgetType { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int SortOrder { get; set; }
    public string Position { get; set; } = "Main";
    public string Size { get; set; } = "Medium";
    public bool IsVisible { get; set; } = true;
    public string? ConfigurationJson { get; set; }
    public string? DataSource { get; set; }
    public int RefreshIntervalSeconds { get; set; } = 300;
    public string RequiredRole { get; set; } = "User";
    public bool IsManagerOnly { get; set; } = false;

    // Navigation Properties
    public virtual ICollection<UserDashboardWidget> UserDashboardWidgets { get; set; } = new List<UserDashboardWidget>();
}
