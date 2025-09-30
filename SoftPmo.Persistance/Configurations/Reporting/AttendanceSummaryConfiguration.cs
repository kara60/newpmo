using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Reporting;

namespace SoftPmo.Persistance.Configurations.Reporting;

public sealed class AttendanceSummaryConfiguration : IEntityTypeConfiguration<AttendanceSummary>
{
    public void Configure(EntityTypeBuilder<AttendanceSummary> builder)
    {
        builder.ToTable("ATTENDANCE_SUMMARY");
        builder.HasKey(x => x.Id);
    }
}
