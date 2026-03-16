using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationDbContext context) : base(context) 
        {
        }
        public async Task<IEnumerable<Question>> GetQuestionsWithAnswersAsync()
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public async Task<Question?> GetQuestionsWithAnswersByIdAsync(Guid questionId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuestionID == questionId);
        }

        public async Task<Question?> GetQuestionWithAnswersAsync(Guid questionId)
        {
            return await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.QuestionID == questionId);
        }
        public async Task<Question?> GetQuestionWithRelationsAsync(Guid questionId)
        {
            return await _dbSet
                .Include(q => q.Answers)
                .Include(q => q.AssessmentQuestions)
                .FirstOrDefaultAsync(q => q.QuestionID == questionId);
        }
    }
}
