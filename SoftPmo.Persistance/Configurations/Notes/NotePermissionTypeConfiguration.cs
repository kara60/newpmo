using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotePermissionTypeConfiguration : IEntityTypeConfiguration<NotePermissionType>
{
    public void Configure(EntityTypeBuilder<NotePermissionType> builder)
    {
        builder.ToTable("NOTE_PERMISSION_TYPE");
        builder.HasKey(x => x.Id);
    }
}
