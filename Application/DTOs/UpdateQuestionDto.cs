using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateQuestionDto
    {
        public string Content { get; set; } = string.Empty;
        public int MaxScore { get; set; }
        public List<UpdateAnswerDto> Answers { get; set; } = new();
    }

}
