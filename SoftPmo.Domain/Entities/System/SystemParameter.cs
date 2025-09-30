using SoftPmo.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Domain.Entities.System
{
    public class SystemParameter : BaseEntity
    {
        public string ParameterName { get; set; } = string.Empty;
        public string ParameterValue { get; set; } = string.Empty;
        public string ParameterType { get; set; } = "String";
        public string Category { get; set; } = "General";
        public bool IsEditable { get; set; } = true;
    }
}
