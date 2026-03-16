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
    public class AnswerRepository:GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public void AddRangeAsync(IEnumerable<Answer> answers)
        {
            _dbSet.AddRange(answers);
        }

        public async Task DeleteByQuestionIdAsync(Guid questionId)
        {
            var answers = await _context.Answers
                .Where(a => a.QuestionID == questionId)
                .ToListAsync();

            _context.Answers.RemoveRange(answers);
        }
        public async Task<Answer?> GetByIdAndQuestionAsync(Guid answerId, Guid questionId)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.AnswerID == answerId && a.QuestionID == questionId);
        }
        public void RemoveRange(IEnumerable<Answer> answers)
        {
            _dbSet.RemoveRange(answers);
        }
    }
}
