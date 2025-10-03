using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("LOCATION");
        builder.HasKey(x => x.Id);
    }
}
