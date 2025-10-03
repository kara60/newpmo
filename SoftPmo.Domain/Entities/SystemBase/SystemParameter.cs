using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.SystemBase;

public class SystemParameter : BaseEntity
{
    public string ParameterName { get; set; } = string.Empty;
    public string ParameterValue { get; set; } = string.Empty;
    public string ParameterType { get; set; } = "String";
    public string Category { get; set; } = "General";
    public bool IsEditable { get; set; } = true;
}
