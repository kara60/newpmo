using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskTodoItemConfiguration : IEntityTypeConfiguration<TaskTodoItem>
{
    public void Configure(EntityTypeBuilder<TaskTodoItem> builder)
    {
        builder.ToTable("TASK_TODO_ITEM");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title).HasMaxLength(500).IsRequired();

        // İlişkiler - İKİ USER İLİŞKİSİ + SELF-REFERENCING!
        builder.HasOne(t => t.Task)
            .WithMany(task => task.TodoItems)
            .HasForeignKey(t => t.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.AssignedUser)
            .WithMany()
            .HasForeignKey(t => t.AssignedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.CompletedByUser)
            .WithMany()
            .HasForeignKey(t => t.CompletedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Priority)
            .WithMany(p => p.TodoItems)
            .HasForeignKey(t => t.PriorityId)
            .OnDelete(DeleteBehavior.Restrict);

        // Self-referencing
        builder.HasOne(t => t.ParentTodoItem)
            .WithMany(t => t.SubTodoItems)
            .HasForeignKey(t => t.ParentTodoItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(t => new { t.TaskId, t.SortOrder });
    }
}
