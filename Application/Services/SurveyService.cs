using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SurveyService(ISurveyRepository surveyRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _surveyRepository = surveyRepository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> CreateSurveyAsync(CreateSurveyDto dto)
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);
            var role = roleClaim?.Value;

            if (role != RoleEnum.Staff.ToString())
            {
                return false;
            }
            var survey = new Survey
            {
                SurveyID = Guid.NewGuid(),
                UserID = dto.UserID,
                Title = dto.Title,
                Description = dto.Description,
                PublishDate = dto.PublishDate,
                Type = dto.Type,
                Status = dto.Status
            };

            await _surveyRepository.AddAsync(survey);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<SurveyDto>> GetAllSurveysAsync()
        {
            var surveys = await _surveyRepository.GetAllAsync();
            return surveys.Select(s => new SurveyDto
            {
                SurveyID = s.SurveyID,
                UserID = s.UserID,
                Title = s.Title,
                Description = s.Description,
                PublishDate = s.PublishDate,
                Type = s.Type,
                Status = s.Status
            });
        }
        public async Task<SurveyDto?> GetSurveyByIdAsync(Guid surveyId)
        {
            var survey = await _surveyRepository.GetByIdAsync(surveyId);
            if (survey == null) return null;

            return new SurveyDto
            {
                SurveyID = survey.SurveyID,
                UserID = survey.UserID,
                Title = survey.Title,
                Description = survey.Description,
                PublishDate = survey.PublishDate,
                Type = survey.Type,
                Status = survey.Status
            };
        }
        public async Task<SurveyDto?> UpdateSurveyAsync(UpdateSurveyDto dto)
        {
            var survey = await _surveyRepository.GetByIdAsync(dto.SurveyID);
            if (survey == null) return null;

            survey.Title = dto.Title;
            survey.Description = dto.Description;
            survey.PublishDate = dto.PublishDate;
            survey.Type = dto.Type;
            survey.Status = dto.Status;
            survey.UserID = dto.UserID;

             _surveyRepository.Update(survey);
            await _unitOfWork.SaveChangesAsync();

            return new SurveyDto
            {
                SurveyID = survey.SurveyID,
                UserID = survey.UserID,
                Title = survey.Title,
                Description = survey.Description,
                PublishDate = survey.PublishDate,
                Type = survey.Type,
                Status = survey.Status
            };
        }
        public async Task<bool> DeleteSurveyAsync(Guid surveyId)
        {
            var survey = await _surveyRepository.GetByIdAsync(surveyId);
            if (survey == null) return false;

             _surveyRepository.Remove(survey);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
