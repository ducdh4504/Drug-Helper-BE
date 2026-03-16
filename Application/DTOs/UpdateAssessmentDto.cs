using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateAssessmentDto
    {
        public string AssessmentName { get; set; } = null!;
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
    }
}
