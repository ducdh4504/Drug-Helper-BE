using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Blog
    {
        public Guid BlogID { get; set; }
        public Guid UserID { get; set; }

        public string? Title { get; set; }
        public string? ImgUrl { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// Draft
        /// Opened
        /// Closed
        /// </summary>
        public PaperStatusEnum Status { get; set; } = PaperStatusEnum.Draft;

        /// <summary>
        /// Low
        /// Medium
        /// High
        /// </summary>
        public AssessmentResultEnum ResultLevel { get; set; } = AssessmentResultEnum.Low;

        // Navigation property
        public User User { get; set; } = null!;
    }
}
