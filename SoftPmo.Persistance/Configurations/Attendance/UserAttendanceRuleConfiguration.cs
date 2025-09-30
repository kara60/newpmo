using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Persistance.Configurations.Attendance
{
    public sealed class UserAttendanceRuleConfiguration : IEntityTypeConfiguration<UserAttendanceRule>
    {
        public void Configure(EntityTypeBuilder<UserAttendanceRule> builder)
        {
            builder.ToTable("USER_ATTENDANCE_RULE");
            builder.HasKey(x => x.Id);
        }
    }
}
