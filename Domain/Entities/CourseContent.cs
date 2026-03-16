namespace Domain.Entities
{
    public class CourseContent
    {
        public Guid CourseContentID { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }

        /// Navigation
        public Course Course { get; set; } = null!;
    }
}
