using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class SubmitAssessmentDto
    {
        public Guid UserId { get; set; }
        public Guid AssessmentId { get; set; }
        public List<AnswerSubmissionDto> Answers { get; set; } = new();
    }
}
