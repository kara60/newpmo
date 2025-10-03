using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameter>
{
    public void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        builder.ToTable("SYSTEM_PARAMETER");
        builder.HasKey(x => x.Id);
    }
}
