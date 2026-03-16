using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateAnswerDto
    {
        public string Content { get; set; } = string.Empty;
        public int Score { get; set; }
    }

}
