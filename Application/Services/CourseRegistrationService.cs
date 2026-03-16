using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Application.Interfaces;

namespace Application.Services
{
    public class CourseRegistrationService : ICourseRegistrationService
    {
        private readonly IRegistrationCourseRepository _registrationRepo;
        private readonly IUnitOfWork _unitOfWork;

        public CourseRegistrationService(
            IRegistrationCourseRepository registrationRepo,
            IUnitOfWork unitOfWork)
        {
            _registrationRepo = registrationRepo;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseRegistrationResultDto?> RegisterAsync(RegisterCourseDto dto)
        {
            bool alreadyRegistered = await _registrationRepo.IsUserRegisteredAsync(dto.UserID, dto.CourseID);
            if (alreadyRegistered)
            {
                return null;
            }

            var registration = new CourseRegistration
            {
                UserID = dto.UserID,
                CourseID = dto.CourseID,
                RegisterTime = DateTime.UtcNow,
                LearningStatus = LearningStatusEnum.InProcess
            };

            await _registrationRepo.AddAsync(registration);
            await _unitOfWork.SaveChangesAsync();

            return new CourseRegistrationResultDto
            {
                RegisterTime = registration.RegisterTime,
                LearningStatus = registration.LearningStatus
            };
        }

        public async Task<CourseRegistrationResultDto?> GetRegistrationResultAsync(Guid userId, Guid courseId)
        {
            var registration = (await _registrationRepo.FindAsync(r => r.UserID == userId && r.CourseID == courseId)).FirstOrDefault();
            if (registration == null)
                return null;

            return new CourseRegistrationResultDto
            {
                RegisterTime = registration.RegisterTime,
                LearningStatus = registration.LearningStatus
            };
        }

        public async Task<List<CourseRegistrationResultDto>> GetRegistrationsByUserAsync(Guid userId)
        {
            var registrations = await _registrationRepo.FindAsync(r => r.UserID == userId);
            return registrations
                .Select(r => new CourseRegistrationResultDto
                {
                    RegisterTime = r.RegisterTime,
                    LearningStatus = r.LearningStatus,
                    CourseId = r.CourseID
                })
                .ToList();
        }
    }
}
