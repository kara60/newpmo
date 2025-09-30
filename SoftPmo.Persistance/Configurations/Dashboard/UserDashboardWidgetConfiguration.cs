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
    public sealed class UserDashboardWidgetConfiguration : IEntityTypeConfiguration<UserDashboardWidget>
    {
        public void Configure(EntityTypeBuilder<UserDashboardWidget> builder)
        {
            builder.ToTable("USER_DASHBOARD_WIDGET");
            builder.HasKey(x => x.Id);
        }
    }
}
