using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Attendance;

namespace SoftPmo.Persistance.Configurations.Attendance;

public sealed class AttendanceRuleConfiguration : IEntityTypeConfiguration<AttendanceRule>
{
    public void Configure(EntityTypeBuilder<AttendanceRule> builder)
    {
        builder.ToTable("ATTENDANCE_RULE");
        builder.HasKey(x => x.Id);
    }
}
