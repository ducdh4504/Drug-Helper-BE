using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AssessmentDto
    {
        public Guid AssessmentID { get; set; }

        public string? AssessmentName { get; set; }

        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
    }
}
