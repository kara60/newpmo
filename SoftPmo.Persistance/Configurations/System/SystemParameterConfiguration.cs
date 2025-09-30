using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Persistance.Configurations.System;

public sealed class SystemParameterConfiguration : IEntityTypeConfiguration<SystemParameter>
{
    public void Configure(EntityTypeBuilder<SystemParameter> builder)
    {
        builder.ToTable("SYSTEM_PARAMETER");
        builder.HasKey(x => x.Id);
    }
}
