using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Shared.Helpers;

namespace Application.Services
{
    public class ProgramParticipationService : IProgramParticipationService
    {
        private readonly IProgramParticipationRepository _programParticipationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProgramParticipationService(IProgramParticipationRepository programParticipationRepository, IUnitOfWork unitOfWork)
        {
            _programParticipationRepository = programParticipationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProgramParticipation?> GetByUserAndProgramAsync(Guid userId, Guid programId)
        {
            var participation = await _programParticipationRepository.GetByUserAndProgramAsync(userId, programId);
            if (participation == null)
                return null;

            return new ProgramParticipation
            {
                JoinTime = participation.JoinTime,
                Status = participation.Status
            };
        }

        public async Task<List<ProgramParticipationInfoDto>> GetByUserIdAsync(Guid userId)
        {
            var participations = await _programParticipationRepository.GetByUserIdWithProgramAsync(userId);

            return participations.Select(p => new ProgramParticipationInfoDto
            {
                ProgramID = p.ProgramID,
                UserID = p.UserID,
                JoinTime = (DateTime)p.JoinTime,
                Status = ActivityStatusEnum.Active
            }).ToList();
        }

        public async Task<List<ProgramParticipationInfoDto>> GetByProgramIdAsync(Guid programId)
        {
            var participations = await _programParticipationRepository.GetByProgramIdWithUserAsync(programId);
            return participations.Select(p => new ProgramParticipationInfoDto
            {
                ProgramID = p.ProgramID,
                UserID = p.UserID,
                JoinTime = (DateTime)p.JoinTime,
                Status = ActivityStatusEnum.Active
            }).ToList();
        }

        public async Task<DateTime?> RegisterAsync(RegisterProgramDto dto)
        {
            var existing = await _programParticipationRepository.GetByUserAndProgramAsync(dto.UserId, dto.ProgramId);

            if (existing != null)
                throw new Exception("User has registered for this program");

            var participation = new ProgramParticipation
            {
                UserID = dto.UserId,
                ProgramID = dto.ProgramId,
                JoinTime = TimeUtils.GetVietnamNow()
            };

            await _programParticipationRepository.AddAsync(participation);
            await _unitOfWork.SaveChangesAsync();

            return (DateTime)participation.JoinTime;
        }

        public async Task<bool> UpdateStatusAsync(UpdateParticipationStatusDto dto)
        {
            var participation = await _programParticipationRepository.GetByUserAndProgramAsync(dto.UserId, dto.ProgramId);

            if (participation == null)
                return false;

            participation.Status = dto.Status;
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
