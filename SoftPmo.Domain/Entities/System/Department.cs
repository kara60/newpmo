using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Domain.Entities.System
{
    public class Department : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? ParentDepartmentId { get; set; }
        public string? ManagerId { get; set; }
        public string LocationId { get; set; }
        public string? ColorCode { get; set; } = "#3B82F6";

        // Navigation Properties
        public virtual Department? ParentDepartment { get; set; }
        public virtual ICollection<Department> SubDepartments { get; set; } = new List<Department>();
        public virtual User? Manager { get; set; }
        public virtual Location Location { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Position> Positions { get; set; } = new List<Position>();

    }
}
