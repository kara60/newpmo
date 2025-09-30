using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Persistance.Configurations.Project;

public sealed class ProjectRoleConfiguration : IEntityTypeConfiguration<ProjectRole>
{
    public void Configure(EntityTypeBuilder<ProjectRole> builder)
    {
        builder.ToTable("PROJECT_ROLE");
        builder.HasKey(x => x.Id);
    }
}
