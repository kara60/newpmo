using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Persistance.Configurations.Project;

public sealed class ProjectTeamMemberConfiguration : IEntityTypeConfiguration<ProjectTeamMember>
{
    public void Configure(EntityTypeBuilder<ProjectTeamMember> builder)
    {
        builder.ToTable("PROJECT_TEAM_MEMBER");
        builder.HasKey(x => x.Id);
    }
}
