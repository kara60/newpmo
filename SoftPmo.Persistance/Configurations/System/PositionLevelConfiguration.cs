using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class PositionLevelConfiguration : IEntityTypeConfiguration<PositionLevel>
{
    public void Configure(EntityTypeBuilder<PositionLevel> builder)
    {
        builder.ToTable("POSITION_LEVEL");
        builder.HasKey(x => x.Id);
    }
}
