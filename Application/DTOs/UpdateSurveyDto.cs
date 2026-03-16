using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateSurveyDto
    {
        public Guid SurveyID { get; set; }
        public Guid UserID { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public SurveyTypeEnum Type { get; set; }
        public PaperStatusEnum Status { get; set; }
    }
}
