using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Persistance.Configurations.Notification;

public sealed class NotificationMConfiguration : IEntityTypeConfiguration<NotificationM>
{
    public void Configure(EntityTypeBuilder<NotificationM> builder)
    {
        builder.ToTable("NOTIFICATION_M");
        builder.HasKey(x => x.Id);
    }
}
