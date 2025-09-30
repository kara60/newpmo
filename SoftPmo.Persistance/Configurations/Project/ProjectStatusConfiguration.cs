using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Persistance.Configurations.Project;

public sealed class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
{
    public void Configure(EntityTypeBuilder<ProjectStatus> builder)
    {
        builder.ToTable("PROJECT_STATUS");
        builder.HasKey(x => x.Id);
    }
}
