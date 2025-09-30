using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotePageAttachmentConfiguration : IEntityTypeConfiguration<NotePageAttachment>
{
    public void Configure(EntityTypeBuilder<NotePageAttachment> builder)
    {
        builder.ToTable("NOTE_PAGE_ATTACHMENT");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.FileName).HasMaxLength(500);
        builder.Property(a => a.ContentType).HasMaxLength(100);

        builder.HasOne(a => a.NotePage)
            .WithMany(p => p.Attachments)
            .HasForeignKey(a => a.NotePageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.UploadedByUser)
            .WithMany()
            .HasForeignKey(a => a.UploadedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
