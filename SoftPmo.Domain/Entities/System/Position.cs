using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Domain.Entities.System
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public int PositionLevelId { get; set; }
        public decimal BillingMultiplier { get; set; } = 1.0m;

        // Navigation Properties
        public virtual Department Department { get; set; } = null!;
        public virtual PositionLevel PositionLevel { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
