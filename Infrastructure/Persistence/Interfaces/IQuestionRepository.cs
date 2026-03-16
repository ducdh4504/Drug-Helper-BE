using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        Task<IEnumerable<Question>> GetQuestionsWithAnswersAsync();
        Task<Question> GetQuestionsWithAnswersByIdAsync(Guid questionId);
        Task<Question?> GetQuestionWithRelationsAsync(Guid questionId);
        Task<Question?> GetQuestionWithAnswersAsync(Guid questionId);

    }
}
