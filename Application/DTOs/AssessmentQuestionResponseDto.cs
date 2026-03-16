using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AssessmentQuestionResponseDto
    {
        public Guid AssessmentId { get; set; }
        public List<QuestionDto> LinkedQuestions { get; set; } = new List<QuestionDto>();
        public int TotalQuestionsLinked { get; set; }
        public bool IsRandomlyGenerated { get; set; }
    }
}
