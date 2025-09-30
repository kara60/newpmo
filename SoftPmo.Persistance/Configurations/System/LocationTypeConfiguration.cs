using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Persistance.Configurations.System;

public sealed class LocationTypeConfiguration : IEntityTypeConfiguration<LocationType>
{
    public void Configure(EntityTypeBuilder<LocationType> builder)
    {
        builder.ToTable("LOCATION_TYPE");
        builder.HasKey(x => x.Id);
    }
}
