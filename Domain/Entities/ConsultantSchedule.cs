using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class ConsultantSchedule
    {
        public Guid ConsultantScheduleID { get; set; }
        public Guid UserID { get; set; }
        public Guid? AppointmentID { get; set; }

        /// <summary>
        /// 'Monday', 'Tuesday', ..., 'Sunday'
        /// </summary>
        public DayOfWeekEnum DayOfWeek { get; set; } = DayOfWeekEnum.Monday;

        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public bool IsAvailable { get; set; }
        public string? Notes { get; set; }

        // Navigation
        public User User { get; set; } = null!;
        public Appointment? Appointment { get; set; }
    }
}
