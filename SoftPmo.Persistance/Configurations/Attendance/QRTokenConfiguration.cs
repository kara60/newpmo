using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Attendance;

namespace SoftPmo.Persistance.Configurations.Attendance;

public sealed class QRTokenConfiguration : IEntityTypeConfiguration<QRToken>
{
    public void Configure(EntityTypeBuilder<QRToken> builder)
    {
        builder.ToTable("QR_TOKEN");
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Token).HasMaxLength(200).IsRequired();
        builder.Property(q => q.TokenType).HasMaxLength(50);

        // İlişkiler
        builder.HasOne(q => q.Location)
            .WithMany(l => l.QRTokens)
            .HasForeignKey(q => q.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(q => q.UsedByUser)
            .WithMany()
            .HasForeignKey(q => q.UsedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(q => q.Token).IsUnique();
    }
}
