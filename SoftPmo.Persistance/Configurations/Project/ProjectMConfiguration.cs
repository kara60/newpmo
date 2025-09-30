using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Persistance.Configurations.Project;

public sealed class ProjectMConfiguration : IEntityTypeConfiguration<ProjectM>
{
    public void Configure(EntityTypeBuilder<ProjectM> builder)
    {
        builder.ToTable("PROJECT_M");
        builder.HasKey(x => x.Id);
    }
}
