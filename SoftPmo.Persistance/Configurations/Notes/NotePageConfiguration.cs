using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotePageConfiguration : IEntityTypeConfiguration<NotePage>
{
    public void Configure(EntityTypeBuilder<NotePage> builder)
    {
        builder.ToTable("NOTE_PAGE");
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title).HasMaxLength(500).IsRequired();
        builder.Property(n => n.ContentType).HasMaxLength(50);

        // İlişkiler - İKİ USER İLİŞKİSİ!
        builder.HasOne(n => n.NotebookSection)
            .WithMany(s => s.Pages)
            .HasForeignKey(n => n.NotebookSectionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.CreatedByUser)
            .WithMany(u => u.CreatedPages)
            .HasForeignKey(n => n.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.LastModifiedByUser)
            .WithMany()
            .HasForeignKey(n => n.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.RelatedTask)
            .WithMany(t => t.RelatedNotePages)
            .HasForeignKey(n => n.RelatedTaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(n => new { n.NotebookSectionId, n.SortOrder });
    }
}
