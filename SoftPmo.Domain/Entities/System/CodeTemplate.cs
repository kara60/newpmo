using SoftPmo.Domain.Abstractions;

namespace SoftPmo.Domain.Entities.System;

public class CodeTemplate : BaseEntity
{
    public string EntityType { get; set; } = string.Empty;
    public string CodeFormat { get; set; } = string.Empty;
    public string Prefix { get; set; } = string.Empty;
    public bool UseYear { get; set; } = true;
    public int SequenceLength { get; set; } = 3;
    public int StartingNumber { get; set; } = 1;
    public int CurrentNumber { get; set; } = 1;
}
