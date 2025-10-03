using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
{
    public void Configure(EntityTypeBuilder<LocationType> builder)
    {
        builder.ToTable("LOCATION_TYPE");
        builder.HasKey(x => x.Id);
    }
}
