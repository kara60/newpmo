using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Persistance.Configurations.System;

public sealed class CodeTemplateConfiguration : IEntityTypeConfiguration<CodeTemplate>
{
    public void Configure(EntityTypeBuilder<CodeTemplate> builder)
    {
        builder.ToTable("CODE_TEMPLATE");
        builder.HasKey(x => x.Id);
    }
}
