using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public class BlogDto
    {
        public Guid BlogID { get; set; }
        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public PaperStatusEnum Status { get; set; }
        public AssessmentResultEnum ResultLevel { get; set; }
        public Guid UserID { get; set; }
        
    }
}
