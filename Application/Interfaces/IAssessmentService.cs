using Application.DTOs;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IAssessmentService
    {
        Task<IEnumerable<AssessmentDto>> GetAllAsync();
        Task<AssessmentQuestionResponseDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAssessmentAsync(CreateAssessmentDto dto);
        Task<bool> UpdateAssessmentAsync(Guid id, UpdateAssessmentDto dto);
        Task<SubmitAssessmentResponseDto> SubmitAsync(SubmitAssessmentDto dto);
        Task<IEnumerable<object>> GetRecommendationsAsync(Guid resultId);
    }

}
