using SoftPmo.Domain.Abstractions;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Domain.Entities.Reporting;

public class AttendanceSummary : BaseEntity
{
    public string UserId { get; set; } = string.Empty;  // ← string

    // BUNLAR INT KALIR
    public int Year { get; set; }
    public int Month { get; set; }
    public int TotalWorkingDays { get; set; }
    public int PresentDays { get; set; }
    public int AbsentDays { get; set; }
    public int LateDays { get; set; }
    public int EarlyLeaveDays { get; set; }
    public int TotalWorkedMinutes { get; set; }
    public int RequiredWorkedMinutes { get; set; }
    public int OvertimeMinutes { get; set; }
    public int UndertimeMinutes { get; set; }
    public int AverageDailyMinutes { get; set; }
    public int VacationDays { get; set; }
    public int SickDays { get; set; }
    public int OfficialHolidayDays { get; set; }

    public TimeSpan AverageArrivalTime { get; set; }
    public TimeSpan AverageDepartureTime { get; set; }
    public decimal AttendanceRate { get; set; }
    public decimal PunctualityRate { get; set; }
    public DateTime LastCalculated { get; set; } = DateTime.UtcNow;

    public virtual User User { get; set; } = null!;
}
