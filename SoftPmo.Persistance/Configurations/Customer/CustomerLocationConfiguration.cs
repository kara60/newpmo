using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Persistance.Configurations.Customer;

public sealed class CustomerLocationConfiguration : IEntityTypeConfiguration<CustomerLocation>
{
    public void Configure(EntityTypeBuilder<CustomerLocation> builder)
    {
        builder.ToTable("CUSTOMER_LOCATION");
        builder.HasKey(c => c.Id);

        builder.HasOne(c => c.Customer)
            .WithMany(cu => cu.CustomerLocations)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.LocationType)
            .WithMany()
            .HasForeignKey(c => c.LocationTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
