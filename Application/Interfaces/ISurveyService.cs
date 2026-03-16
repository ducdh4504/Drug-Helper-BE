using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISurveyService
    {
        Task<bool> CreateSurveyAsync(CreateSurveyDto dto);
        Task<IEnumerable<SurveyDto>> GetAllSurveysAsync();
        Task<SurveyDto?> GetSurveyByIdAsync(Guid surveyId);
        Task<SurveyDto?> UpdateSurveyAsync(UpdateSurveyDto dto);
        Task<bool> DeleteSurveyAsync(Guid surveyId);
    }
}
