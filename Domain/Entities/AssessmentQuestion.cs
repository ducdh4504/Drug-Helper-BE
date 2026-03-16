namespace Domain.Entities
{
    public class AssessmentQuestion
    {
        public Guid AssessmentID { get; set; }
        public Guid QuestionID { get; set; }

        // Navigation
        public Assessment Assessment { get; set; } = null!;
        public Question Question { get; set; } = null!;
    }
}
