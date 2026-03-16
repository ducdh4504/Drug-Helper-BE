using Domain.Enums;

namespace Domain.Entities
{
    public class Course
    {
        public Guid CourseID { get; set; }
        public string contentSummary { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 'Active' or 'InActive'
        /// </summary>
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;

        /// <summary>
        /// Low
        /// Medium
        /// High
        /// </summary>
        public AssessmentResultEnum ResultLevel { get; set; } = AssessmentResultEnum.Low;
        public int? AgeMin { get; set; }
        public int? Capacity { get; set; }

        // Navigation
        public ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();
        public ICollection<CourseContent> CourseContents { get; set; } = new List<CourseContent>();
    }
}
