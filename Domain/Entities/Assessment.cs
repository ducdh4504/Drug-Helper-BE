using Domain.Enums;

namespace Domain.Entities
{
    public class Assessment
    {
        public Guid AssessmentID { get; set; }

        public string? AssessmentName { get; set; }
        public ActivityStatusEnum Status { get; set; }

        // Navigation
        public ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();
        public ICollection<AssessmentResult> AssessmentResults { get; set; } = new List<AssessmentResult>();
    }
}
