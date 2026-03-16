using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class AssessmentQuestionRepository : GenericRepository<AssessmentQuestion>, IAssessmentQuestionRepository
    {
        public AssessmentQuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<AssessmentQuestion>> GetByAssessmentIdAsync(Guid assessmentId)
        {
            return await _dbSet
                .Include(aq => aq.Question)
                .Include(aq => aq.Assessment)
                .Where(aq => aq.AssessmentID == assessmentId)
                .ToListAsync();
        }

        public async Task<List<AssessmentQuestion>> GetByQuestionIdAsync(Guid questionId)
        {
            return await _dbSet
                .Include(aq => aq.Question)
                .Include(aq => aq.Assessment)
                .Where(aq => aq.QuestionID == questionId)
                .ToListAsync();
        }

        public async Task<List<Guid>> GetLinkedQuestionIdsAsync(Guid assessmentId)
        {
            return await _dbSet
                .Where(aq => aq.AssessmentID == assessmentId)
                .Select(aq => aq.QuestionID)
                .ToListAsync();
        }

        public async Task<int> GetQuestionCountByAssessmentAsync(Guid assessmentId)
        {
            return await _dbSet
                .CountAsync(aq => aq.AssessmentID == assessmentId);
        }

        public async Task<bool> IsQuestionLinkedToAssessmentAsync(Guid assessmentId, Guid questionId)
        {
            return await _dbSet
                .AnyAsync(aq => aq.AssessmentID == assessmentId && aq.QuestionID == questionId);
        }

        public async Task<bool> RemoveQuestionFromAssessmentAsync(Guid assessmentId, Guid questionId)
        {
            var assessmentQuestion = await _dbSet
                .FirstOrDefaultAsync(aq => aq.AssessmentID == assessmentId && aq.QuestionID == questionId);

            if (assessmentQuestion == null)
                return false;

            _dbSet.Remove(assessmentQuestion);
            return true;
        }

        public void RemoveRange(IEnumerable<AssessmentQuestion> assessmentQuestions)
        {
            _dbSet.RemoveRange(assessmentQuestions);
        }
    }
}
