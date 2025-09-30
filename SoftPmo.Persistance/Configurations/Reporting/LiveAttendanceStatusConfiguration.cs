using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Reporting;

namespace SoftPmo.Persistance.Configurations.Reporting;

public sealed class LiveAttendanceStatusConfiguration : IEntityTypeConfiguration<LiveAttendanceStatus>
{
    public void Configure(EntityTypeBuilder<LiveAttendanceStatus> builder)
    {
        builder.ToTable("LIVE_ATTENDANCE_STATUS");
        builder.HasKey(x => x.Id);
    }
}
