using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NoteCommentConfiguration : IEntityTypeConfiguration<NoteComment>
{
    public void Configure(EntityTypeBuilder<NoteComment> builder)
    {
        builder.ToTable("NOTE_COMMENT");
        builder.HasKey(c => c.Id);

        // İlişkiler - İKİ USER İLİŞKİSİ + SELF-REFERENCING!
        builder.HasOne(c => c.NotePage)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.NotePageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Author)
            .WithMany(u => u.AuthoredComments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.ResolvedByUser)
            .WithMany()
            .HasForeignKey(c => c.ResolvedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Self-referencing
        builder.HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
