using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class SurveyResultService : ISurveyResultService
    {
        private readonly ISurveyResultRepository _surveyResultRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SurveyResultService(ISurveyResultRepository surveyResultRepository, IUnitOfWork unitOfWork)
        {
            _surveyResultRepository = surveyResultRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> LinkSurveyProgramAsync(CreateSurveyResultDto dto)
        {
            var surveyResult = new SurveyResult
            {
                SurveyID = dto.SurveyID,
                ProgramID = dto.ProgramID,
            };
            await _surveyResultRepository.AddAsync(surveyResult);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<SurveyResultDto> UpdateSurveyResultAsync(UpdateSurveyResultDto dto)
        {
            var existing = await _surveyResultRepository.GetBySurveyAndProgramAsync(dto.SurveyID, dto.ProgramID);

            if (existing == null)
                throw new Exception("Survey result not found.");

            existing.UserID = dto.UserID;
            existing.ResponseData = dto.ResponseData;
            existing.SubmitTime = DateTime.UtcNow;

            _surveyResultRepository.Update(existing);
            await _unitOfWork.SaveChangesAsync();

            return new SurveyResultDto
            {
                SurveyID = existing.SurveyID,
                ProgramID = existing.ProgramID,
                UserID = existing.UserID,
                ResponseData = existing.ResponseData,
                SubmitTime = existing.SubmitTime
            };
        }

        public async Task<IEnumerable<SurveyResultDto>> GetByServeyIdAsync(Guid surveyid)
        {
            var listSurveyResult = await _surveyResultRepository.GetBySurveyIdAsync(surveyid);

            return listSurveyResult.Select(p => new SurveyResultDto
            {
                SurveyID = p.SurveyID,
                ProgramID = p.ProgramID,
                UserID = p.UserID,
                ResponseData = p.ResponseData,
                SubmitTime = p.SubmitTime
            });
        }

        public async Task<SurveyResultDto?> GetBySurveyAndProgramIdAsync(Guid userId, Guid surveyId)
        {
            var result = await _surveyResultRepository.GetBySurveyAndProgramAsync(userId, surveyId);

            if (result == null) return null;

            return new SurveyResultDto
            {
                SurveyID = result.SurveyID,
                ProgramID = result.ProgramID,
                UserID = result.UserID,
                ResponseData = result.ResponseData,
                SubmitTime = result.SubmitTime
            };
        }

        public async Task<List<Guid>> GetSurveyIdsByProgramIdAsync(Guid programId)
        {
            var results = await _surveyResultRepository.FindAsync(r => r.ProgramID == programId);
            return results.Select(r => r.SurveyID).Distinct().ToList();
        }

        public async Task<IEnumerable<object>> GetSurveyResultCountsByProgramAsync(Guid programId)
        {
            var results = await _surveyResultRepository.FindAsync(r => r.ProgramID == programId);
            var grouped = results
                .GroupBy(r => r.SurveyID)
                .Select(g => new {
                    SurveyID = g.Key,
                    Count = g.Count(r => r.UserID != null)
                });
            return grouped.ToList();
        }
    }
}
