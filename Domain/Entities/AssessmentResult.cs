using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class AssessmentResult
    {
        public Guid ResultID { get; set; }
        public Guid AssessmentID { get; set; }
        public Guid UserID { get; set; }

        /// <summary>
        /// Low
        /// Medium
        /// High
        /// </summary>
        public AssessmentResultEnum ResultLevel { get; set; } = AssessmentResultEnum.Low;
        public int Score { get; set; }
        public DateTime? TakeTime { get; set; }


        // Navigation
        public Assessment Assessment { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
