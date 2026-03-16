using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class CourseRegistration
    {
        public Guid UserID { get; set; }
        public Guid CourseID { get; set; }

        public DateTime RegisterTime { get; set; }

        /// <summary>
        /// 'In process', 'Completed', 'Closed'
        /// </summary>
        public LearningStatusEnum LearningStatus { get; set; } = LearningStatusEnum.InProcess;

        // Navigation
        public User User { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}
