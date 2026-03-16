namespace Domain.Entities
{
    public class Question
    {
        public Guid QuestionID { get; set; }

        public string Content { get; set; } = string.Empty;
        public int MaxScore { get; set; }

        // Navigation
        public ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
