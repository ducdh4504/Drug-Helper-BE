using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AssessmentResultDto
    {
        public int Score { get; set; }
        public AssessmentResultEnum ResultLevel { get; set; } = AssessmentResultEnum.Low;
    }
}
