using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoftPmo.Domain.Entities.Attendance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPmo.Persistance.Configurations.Attendance
{
    public sealed class AttendanceExceptionTypeConfiguration : IEntityTypeConfiguration<AttendanceExceptionType>
    {
        public void Configure(EntityTypeBuilder<AttendanceExceptionType> builder)
        {
            builder.ToTable("ATTENDANCE_EXCEPTION_TYPE");
            builder.HasKey(x => x.Id);
        }
    }
}
