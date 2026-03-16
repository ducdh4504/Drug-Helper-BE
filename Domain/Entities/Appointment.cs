using Domain.Enums;

namespace Domain.Entities
{
    public class Appointment
    {
        public Guid AppointmentID { get; set; }
        public Guid MemberID { get; set; }
        public Guid ConsultantID { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// 'No response yet', 'Accepted', 'Rejected'
        /// </summary>
        public AppointmentResponseEnum Status { get; set; } = AppointmentResponseEnum.NoResponseYet;

        public string? Note { get; set; }

        // Navigation
        public User Member { get; set; } = null!;
        public User Consultant { get; set; } = null!;
        public ICollection<ConsultantSchedule> ConsultantSchedules { get; set; } = new List<ConsultantSchedule>();
    }
}
