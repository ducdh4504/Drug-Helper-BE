using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IAssessmentQuestionRepository : IGenericRepository<AssessmentQuestion>
    {
        Task<bool> RemoveQuestionFromAssessmentAsync(Guid assessmentId, Guid questionId);
        Task<List<Guid>> GetLinkedQuestionIdsAsync(Guid assessmentId);
        Task<int> GetQuestionCountByAssessmentAsync(Guid assessmentId);
        Task<bool> IsQuestionLinkedToAssessmentAsync(Guid assessmentId, Guid questionId);
        Task<List<AssessmentQuestion>> GetByAssessmentIdAsync(Guid assessmentId);
        Task<List<AssessmentQuestion>> GetByQuestionIdAsync(Guid questionId);
        void RemoveRange(IEnumerable<AssessmentQuestion> assessmentQuestions);
    }
}
