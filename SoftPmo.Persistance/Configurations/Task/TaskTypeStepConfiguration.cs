using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskTypeStepConfiguration : IEntityTypeConfiguration<TaskTypeStep>
{
    public void Configure(EntityTypeBuilder<TaskTypeStep> builder)
    {
        builder.ToTable("TASK_TYPE_STEP");
        builder.HasKey(t => t.Id);

        // Properties
        builder.Property(t => t.TaskTypeId).IsRequired();
        builder.Property(t => t.StepId).IsRequired();

        // İlişkiler - AÇIKÇA TANIMLI
        builder.HasOne(t => t.TaskType)
            .WithMany(tt => tt.TaskTypeSteps)
            .HasForeignKey(t => t.TaskTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Step)
            .WithMany(s => s.TaskTypeSteps)
            .HasForeignKey(t => t.StepId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.DefaultDepartment)
            .WithMany()
            .HasForeignKey(t => t.DefaultDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index
        builder.HasIndex(t => new { t.TaskTypeId, t.SortOrder });
    }
}
