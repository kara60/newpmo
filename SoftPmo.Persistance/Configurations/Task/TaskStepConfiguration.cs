using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskStepConfiguration : IEntityTypeConfiguration<TaskStep>
{
    public void Configure(EntityTypeBuilder<TaskStep> builder)
    {
        builder.ToTable("TASK_STEP");
        builder.HasKey(t => t.Id);

        builder.HasOne(t => t.Task)
            .WithMany(task => task.TaskSteps)
            .HasForeignKey(t => t.TaskId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Step)
            .WithMany(s => s.TaskSteps)
            .HasForeignKey(t => t.StepId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.AssignedUser)
            .WithMany(u => u.AssignedTaskSteps)
            .HasForeignKey(t => t.AssignedUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Department)
            .WithMany()
            .HasForeignKey(t => t.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.TaskStatus)
            .WithMany(ts => ts.TaskSteps)
            .HasForeignKey(t => t.TaskStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
