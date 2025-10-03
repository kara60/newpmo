using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Persistance.Configurations.Activity;

public sealed class ActivityMConfiguration : IEntityTypeConfiguration<ActivityM>
{
    public void Configure(EntityTypeBuilder<ActivityM> builder)
    {
        builder.ToTable("ACTIVITY_M");
        builder.HasKey(a => a.Id);

        // İlişkiler - İKİ USER İLİŞKİSİ!
        builder.HasOne(a => a.User)
            .WithMany(u => u.Activities)
            .HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.ApprovedByUser)
            .WithMany()
            .HasForeignKey(a => a.ApprovedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Task)
            .WithMany(t => t.Activities)
            .HasForeignKey(a => a.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.TaskStep)
            .WithMany(ts => ts.Activities)
            .HasForeignKey(a => a.TaskStepId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Location)
            .WithMany()
            .HasForeignKey(a => a.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.CustomerLocation)
            .WithMany(cl => cl.Activities)
            .HasForeignKey(a => a.CustomerLocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.ActivityStatus)
            .WithMany(s => s.Activities)
            .HasForeignKey(a => a.ActivityStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(a => new { a.UserId, a.ActivityDate });
    }
}
