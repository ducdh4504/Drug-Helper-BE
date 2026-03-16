using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IAnswerRepository:IGenericRepository<Answer>
    {
        Task<Answer?> GetByIdAndQuestionAsync(Guid answerId, Guid questionId);
        void RemoveRange(IEnumerable<Answer> answers);
        void AddRangeAsync(IEnumerable<Answer> answers);
        Task DeleteByQuestionIdAsync(Guid questionId);
    }
}
