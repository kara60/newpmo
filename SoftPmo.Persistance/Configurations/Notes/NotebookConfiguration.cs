using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotebookConfiguration : IEntityTypeConfiguration<Notebook>
{
    public void Configure(EntityTypeBuilder<Notebook> builder)
    {
        builder.ToTable("NOTEBOOK");
        builder.HasKey(x => x.Id);
    }
}
