using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Persistance.Configurations.Notes
{
    public sealed class NotebookSectionConfiguration : IEntityTypeConfiguration<NotebookSection>
    {
        public void Configure(EntityTypeBuilder<NotebookSection> builder)
        {
            builder.ToTable("NOTEBOOK_SECTION");
            builder.HasKey(x => x.Id);
        }
    }
}
