using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionDto?> CreateQuestionAsync(CreateQuestionDto dto);
        Task<IEnumerable<QuestionDto>> GetAllQuestionsAsync();
        Task<bool> DeleteQuestionAsync(Guid questionId);
        Task<QuestionDto?> UpdateAsync(Guid questionId, UpdateQuestionDto dto);
    }
}
