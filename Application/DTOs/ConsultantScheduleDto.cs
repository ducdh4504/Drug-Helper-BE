using Domain.Enums;

namespace Application.DTOs
{
    public class ConsultantScheduleDto
    {
        public Guid ConsultantScheduleID { get; set; }
        public DayOfWeekEnum DayOfWeek { get; set; } = DayOfWeekEnum.Monday;
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAvailable { get; set; }
        public string? Notes { get; set; }
    }
}
