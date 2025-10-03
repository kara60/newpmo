using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Customer;

namespace SoftPmo.Persistance.Configurations.Customer;

public sealed class CustomerMConfiguration : IEntityTypeConfiguration<CustomerM>
{
    public void Configure(EntityTypeBuilder<CustomerM> builder)
    {
        builder.ToTable("CUSTOMER_M");
        builder.HasKey(x => x.Id);
    }
}
