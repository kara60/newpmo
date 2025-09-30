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
    public sealed class AttendanceExceptionConfiguration : IEntityTypeConfiguration<AttendanceException>
    {
        public void Configure(EntityTypeBuilder<AttendanceException> builder)
        {
            builder.ToTable("ATTENDANCE_EXCEPTION");
            builder.HasKey(e => e.Id);

            // İlişkiler - İKİ USER İLİŞKİSİ!
            builder.HasOne(e => e.User)
                .WithMany(u => u.AttendanceExceptions)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ApprovedByUser)
                .WithMany()
                .HasForeignKey(e => e.ApprovedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AttendanceExceptionType)
                .WithMany(t => t.AttendanceExceptions)
                .HasForeignKey(e => e.AttendanceExceptionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
