using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Persistance.Configurations.SystemBase;

public sealed class CodeTemplateConfiguration : IEntityTypeConfiguration<CodeTemplate>
{
    public void Configure(EntityTypeBuilder<CodeTemplate> builder)
    {
        builder.ToTable("CODE_TEMPLATE");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.EntityType);
    }
}
