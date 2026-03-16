using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Survey
    {
        public Guid SurveyID { get; set; }
        public Guid UserID { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// Pre
        /// Post
        /// </summary>
        public SurveyTypeEnum Type { get; set; } = SurveyTypeEnum.Post;

        /// <summary>
        /// Draft
        /// Opened
        /// Closed
        /// </summary>
        public PaperStatusEnum Status { get; set; } = PaperStatusEnum.Draft;

        // Navigation property
        public User User { get; set; } = null!;
        public ICollection<SurveyResult> SurveyResults { get; set; } = new List<SurveyResult>();

    }
}
