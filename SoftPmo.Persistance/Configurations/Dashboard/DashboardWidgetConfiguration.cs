using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Persistance.Configurations.Dashboard
{
    public sealed class DashboardWidgetConfiguration : IEntityTypeConfiguration<DashboardWidget>
    {
        public void Configure(EntityTypeBuilder<DashboardWidget> builder)
        {
            builder.ToTable("DASHBOARD_WIDGET");
            builder.HasKey(x => x.Id);
        }
    }
}
