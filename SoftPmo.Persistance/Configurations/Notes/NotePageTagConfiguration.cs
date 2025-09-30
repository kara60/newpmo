using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotePageTagConfiguration : IEntityTypeConfiguration<NotePageTag>
{
    public void Configure(EntityTypeBuilder<NotePageTag> builder)
    {
        builder.ToTable("NOTE_PAGE_TAG");
        builder.HasKey(npt => npt.Id);

        builder.HasOne(npt => npt.NotePage)
            .WithMany(p => p.NotePageTags)
            .HasForeignKey(npt => npt.NotePageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(npt => npt.NoteTag)
            .WithMany(t => t.NotePageTags)
            .HasForeignKey(npt => npt.NoteTagId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(npt => npt.AddedByUser)
            .WithMany()
            .HasForeignKey(npt => npt.AddedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Unique constraint
        builder.HasIndex(npt => new { npt.NotePageId, npt.NoteTagId }).IsUnique();
    }
}
