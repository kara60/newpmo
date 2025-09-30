using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskMConfiguration : IEntityTypeConfiguration<TaskM>
{
    public void Configure(EntityTypeBuilder<TaskM> builder)
    {
        builder.ToTable("TASK_M");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title).HasMaxLength(500).IsRequired();

        // İlişkiler - İKİ USER İLİŞKİSİ!
        builder.HasOne(t => t.CreatedByUser)
            .WithMany(u => u.CreatedTasks)
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.MainResponsibleUser)
            .WithMany(u => u.MainResponsibleTasks)
            .HasForeignKey(t => t.MainResponsibleUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Customer)
            .WithMany(c => c.Tasks)
            .HasForeignKey(t => t.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.TaskType)
            .WithMany(tt => tt.Tasks)
            .HasForeignKey(t => t.TaskTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.TaskStatus)
            .WithMany(ts => ts.Tasks)
            .HasForeignKey(t => t.TaskStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Priority)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.PriorityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(t => new { t.CustomerId, t.ProjectId });
        builder.HasQueryFilter(t => t.IsActive);
    }
}
