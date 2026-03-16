using Application.DTOs;

namespace Application.Interfaces
{
    public interface IAssessmentQuestionService
    {
        Task<AssessmentQuestionResponseDto> LinkQuestionToAssessmentAsync(AssessmentQuestionRequestDto request);
        Task<AssessmentQuestionResponseDto> LinkRandomQuestionsToAssessmentAsync(Guid assessmentId, int questionCount);
        Task<AssessmentQuestionResponseDto> LinkSpecificQuestionAsync(Guid assessmentId, Guid questionId);
        Task<bool> IsAssessmentExistsAsync(Guid assessmentId);
        Task<bool> IsQuestionExistsAsync(Guid questionId);
        Task<List<Guid>> GetRandomQuestionIdsAsync(int count, Guid? excludeAssessmentId = null);
        Task<bool> IsQuestionAlreadyLinkedAsync(Guid assessmentId, Guid questionId);
        Task<bool> RemoveQuestionFromAssessmentAsync(Guid assessmentId, Guid questionId);
    }
}
