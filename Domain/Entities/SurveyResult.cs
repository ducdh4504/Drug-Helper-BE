namespace Domain.Entities
{
    public class SurveyResult
    {
        public Guid SurveyID { get; set; }
        public Guid ProgramID { get; set; }
        public Guid? UserID { get; set; } 

        public string? ResponseData { get; set; }
        public DateTime? SubmitTime { get; set; }

        // Navigation properties
        public Survey Survey { get; set; } = null!;
        public CommunicationProgram CommunicationProgram { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
