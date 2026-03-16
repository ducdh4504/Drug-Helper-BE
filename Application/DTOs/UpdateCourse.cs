using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateCourse
    {
        public string Title { get; set; }
        public string? ImgUrl { get; set; }
        public string ContentSummary { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityStatusEnum Status { get; set; }
        public int AgeMin { get; set; }
        public int Capacity { get; set; }
        public AssessmentResultEnum ResultLevel { get; set; } = AssessmentResultEnum.Low;
    }
}
