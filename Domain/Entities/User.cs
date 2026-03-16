using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? ImgUrl { get; set; } 
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public RoleEnum Role { get; set; } = RoleEnum.Member;

        /// <summary>
        /// Active
        /// InActive
        /// </summary>
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;


        // Navigation properties

        public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
        public ICollection<Survey> Surveys { get; set; } = new List<Survey>();
        public ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();
        public ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<ConsultantSchedule> ConsultantSchedules { get; set; } = new List<ConsultantSchedule>();
        public ICollection<ProgramParticipation> Participations { get; set; } = new List<ProgramParticipation>();
        public ICollection<AssessmentResult> AssessmentResults { get; set; } = new List<AssessmentResult>();
    }
}
