using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Persistance.Configurations.Customer
{
    public sealed class CustomerLocationConfiguration : IEntityTypeConfiguration<CustomerLocation>
    {
        public void Configure(EntityTypeBuilder<CustomerLocation> builder)
        {
            builder.ToTable("CUSTOMER_LOCATION");
            builder.HasKey(x => x.Id);
        }
    }
}
