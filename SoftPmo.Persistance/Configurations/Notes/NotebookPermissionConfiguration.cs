using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;

namespace SoftPmo.Persistance.Configurations.Notes;

public sealed class NotebookPermissionConfiguration : IEntityTypeConfiguration<NotebookPermission>
{
    public void Configure(EntityTypeBuilder<NotebookPermission> builder)
    {
        builder.ToTable("NOTEBOOK_PERMISSION");
        builder.HasKey(p => p.Id);

        // İlişkiler - İKİ USER İLİŞKİSİ!
        builder.HasOne(p => p.Notebook)
            .WithMany(n => n.Permissions)
            .HasForeignKey(p => p.NotebookId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.User)
            .WithMany(u => u.NotebookPermissions)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.GrantedByUser)
            .WithMany()
            .HasForeignKey(p => p.GrantedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.PermissionType)
            .WithMany(t => t.NotebookPermissions)
            .HasForeignKey(p => p.PermissionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
