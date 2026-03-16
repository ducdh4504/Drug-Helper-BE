using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class CourseRegistrationResultDto
    {
        public DateTime RegisterTime { get; set; }
        public LearningStatusEnum LearningStatus { get; set; }
        public Guid CourseId { get; set; }
    }
}
