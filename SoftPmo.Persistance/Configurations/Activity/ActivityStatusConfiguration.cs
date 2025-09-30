using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Persistance.Configurations.Activity;

public sealed class ActivityStatusConfiguration : IEntityTypeConfiguration<ActivityStatus>
{
    public void Configure(EntityTypeBuilder<ActivityStatus> builder)
    {
        builder.ToTable("ACTIVITY_STATUS");
        builder.HasKey(t => t.Id);
    }
}
