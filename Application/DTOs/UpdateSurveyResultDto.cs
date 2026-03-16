using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UpdateSurveyResultDto
    {
        public Guid SurveyID { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? UserID { get; set; }
        public string? ResponseData { get; set; }
    }
}
