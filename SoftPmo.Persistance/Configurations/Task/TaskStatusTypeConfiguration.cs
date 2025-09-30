using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Persistance.Configurations.Task;

public sealed class TaskStatusTypeConfiguration : IEntityTypeConfiguration<TaskStatusType>
{
    public void Configure(EntityTypeBuilder<TaskStatusType> builder)
    {
        builder.ToTable("TASK_STATUS_TYPE");
        builder.HasKey(x => x.Id);
    }
}
