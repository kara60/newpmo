using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Reporting;

namespace SoftPmo.Persistance.Configurations.Reporting;

public sealed class DailyAttendanceReportConfiguration : IEntityTypeConfiguration<DailyAttendanceReport>
{
    public void Configure(EntityTypeBuilder<DailyAttendanceReport> builder)
    {
        builder.ToTable("DAILY_ATTENDANCE_REPORT");
        builder.HasKey(x => x.Id);
    }
}
