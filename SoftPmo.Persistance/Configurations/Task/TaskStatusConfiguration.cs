using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStatus = SoftPmo.Domain.Entities.Task.TaskStatus;


namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskStatusConfiguration : IEntityTypeConfiguration<TaskStatus>
{
    public void Configure(EntityTypeBuilder<TaskStatus> builder)
    {
        builder.ToTable("TASK_STATUS");
        builder.HasKey(x => x.Id);
    }
}
