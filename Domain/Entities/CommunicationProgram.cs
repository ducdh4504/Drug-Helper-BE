using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CommunicationProgram
    {
        public Guid ProgramID { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImgUrl { get; set; } = null;
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string? Speaker { get; set; }
        public string? SpeakerImageUrl { get; set; } = null;
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
        /// <summary>
        /// 'online'
        /// 'offline'
        /// </summary>
        public LocationTypeEnum LocationType { get; set; } = LocationTypeEnum.online;

        public string Location { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<ProgramParticipation> Participants { get; set; } = new List<ProgramParticipation>();
        public ICollection<SurveyResult> SurveyResults { get; set; } = new List<SurveyResult>();
    }
}
