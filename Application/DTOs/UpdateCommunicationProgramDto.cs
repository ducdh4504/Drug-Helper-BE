using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateCommunicationProgramDto
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
        public LocationTypeEnum LocationType { get; set; } = LocationTypeEnum.online;
        public string Location { get; set; } = string.Empty;
    }
}
