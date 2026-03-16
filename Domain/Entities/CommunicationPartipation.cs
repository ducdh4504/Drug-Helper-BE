using Domain.Enums;

namespace Domain.Entities
{
    public class ProgramParticipation
    {
        public Guid UserID { get; set; }
        public Guid ProgramID { get; set; }
        public DateTime? JoinTime { get; set; }
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
        // Navigation properties
        public User User { get; set; } = null!;
        public CommunicationProgram CommunicationProgram { get; set; } = null!;
    }
}
