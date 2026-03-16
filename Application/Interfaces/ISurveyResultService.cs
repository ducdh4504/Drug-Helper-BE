using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISurveyResultService
    {
        Task<SurveyResultDto> UpdateSurveyResultAsync(UpdateSurveyResultDto dto);
        Task<IEnumerable<SurveyResultDto>> GetByServeyIdAsync(Guid surveyid);
        Task<SurveyResultDto?> GetBySurveyAndProgramIdAsync(Guid surveyId, Guid programId);
        Task<bool> LinkSurveyProgramAsync(CreateSurveyResultDto dto);
        Task<List<Guid>> GetSurveyIdsByProgramIdAsync(Guid programId);
        Task<IEnumerable<object>> GetSurveyResultCountsByProgramAsync(Guid programId);
    }
}
