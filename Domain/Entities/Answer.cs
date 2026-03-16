namespace Domain.Entities
{
    public class Answer
    {
        public Guid AnswerID { get; set; }
        public Guid QuestionID { get; set; }

        public string Content { get; set; } = string.Empty;
        public int Score { get; set; }

        // Navigation
        public Question Question { get; set; } = null!;
    }
}
