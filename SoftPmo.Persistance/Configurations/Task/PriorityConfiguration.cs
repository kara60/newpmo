using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class PriorityConfiguration : IEntityTypeConfiguration<Priority>
{
    public void Configure(EntityTypeBuilder<Priority> builder)
    {
        builder.ToTable("PRIORITY");
        builder.HasKey(x => x.Id);
    }
}
