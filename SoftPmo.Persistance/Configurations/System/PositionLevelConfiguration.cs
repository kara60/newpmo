using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Persistance.Configurations.System;

public sealed class PositionLevelConfiguration : IEntityTypeConfiguration<PositionLevel>
{
    public void Configure(EntityTypeBuilder<PositionLevel> builder)
    {
        builder.ToTable("POSITION_LEVEL");
        builder.HasKey(x => x.Id);
    }
}
