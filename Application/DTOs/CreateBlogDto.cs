using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class CreateBlogDto
    {
        public Guid UserID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public PaperStatusEnum Status { get; set; }
        public AssessmentResultEnum ResultLevel { get; set; }

    }
}
