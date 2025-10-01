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
    public sealed class AttendanceSessionConfiguration : IEntityTypeConfiguration<AttendanceSession>
    {
        public void Configure(EntityTypeBuilder<AttendanceSession> builder)
        {
            builder.ToTable("ATTENDANCE_SESSION");
            builder.HasKey(a => a.Id);

            // İlişkiler - İKİ LOCATION İLİŞKİSİ!
            builder.HasOne(a => a.User)
                .WithMany(u => u.AttendanceSessions)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CheckInLocation)
                .WithMany()  // Location'da collection yok
                .HasForeignKey(a => a.CheckInLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.CheckOutLocation)
                .WithMany()
                .HasForeignKey(a => a.CheckOutLocationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Index
            builder.HasIndex(a => new { a.UserId, a.SessionDate });
        }
    }
}
