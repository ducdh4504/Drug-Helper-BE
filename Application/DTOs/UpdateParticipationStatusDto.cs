using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateParticipationStatusDto
    {
        public Guid UserId { get; set; }
        public Guid ProgramId { get; set; }
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
    }

}
