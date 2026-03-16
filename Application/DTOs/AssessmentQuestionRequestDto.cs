using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class AssessmentQuestionRequestDto
    {
        [Required(ErrorMessage = "Assessment ID là bắt buộc")]
        public Guid AssessmentId { get; set; }

        /// <summary>
        /// Question ID - nếu null thì sẽ random question
        /// </summary>
        public Guid? QuestionId { get; set; }

        /// <summary>
        /// Số lượng câu hỏi cần random (chỉ dùng khi QuestionId = null)
        /// </summary>
        public int? RandomQuestionCount { get; set; } = 1;
    }
}
