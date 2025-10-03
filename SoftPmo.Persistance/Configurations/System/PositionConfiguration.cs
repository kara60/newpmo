using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("POSITION");
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PositionLevel)
            .WithMany(pl => pl.Positions)
            .HasForeignKey(p => p.PositionLevelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
