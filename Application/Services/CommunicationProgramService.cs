using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class CommunicationProgramService : ICommunicationProgramService
    {
        private readonly ICommunicationProgramRepository _communicationProgramRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CommunicationProgramService(ICommunicationProgramRepository communicationProgramRepository, IUnitOfWork unitOfWork)
        {
            _communicationProgramRepository = communicationProgramRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CommunicationProgramDto dto)
        {
            var communicationProgram = new CommunicationProgram
            {
                ProgramID = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                ImgUrl = dto.ImgUrl,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Speaker = dto.Speaker,
                SpeakerImageUrl = dto.SpeakerImageUrl,
                LocationType = dto.LocationType,
                Location = dto.Location
            };
            await _communicationProgramRepository.AddAsync(communicationProgram);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid ProgramID)
        {
            var communicationProgram = await _communicationProgramRepository.GetByIdAsync(ProgramID);
            if (communicationProgram == null)
            {
                return false;
            }
            _communicationProgramRepository.Remove(communicationProgram);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<UpdateCommunicationProgramDto?> UpdateAsync(UpdateCommunicationProgramDto dto)
        {
            var communicationProgram = await _communicationProgramRepository.GetByIdAsync(dto.ProgramID);
            if (communicationProgram == null)
            {
                return null;
            }

            communicationProgram.Name = dto.Name;
            communicationProgram.Description = dto.Description;
            communicationProgram.ImgUrl = dto.ImgUrl;
            communicationProgram.Date = dto.Date;
            communicationProgram.StartTime = dto.StartTime;
            communicationProgram.EndTime = dto.EndTime;
            communicationProgram.Speaker = dto.Speaker;
            communicationProgram.SpeakerImageUrl = dto.SpeakerImageUrl;
            communicationProgram.Status = dto.Status;
            communicationProgram.LocationType = dto.LocationType;
            communicationProgram.Location = dto.Location;

            await _unitOfWork.SaveChangesAsync();
            return dto;
        }

        // Lấy tất cả Communication Program
        public async Task<IEnumerable<CommunicationProgramDto>> GetAllAsync()
        {
            var programs = await _communicationProgramRepository.GetAllAsync();
            return programs.Select(p => new CommunicationProgramDto
            {
                ProgramID = p.ProgramID,
                Name = p.Name,
                Description = p.Description,
                ImgUrl = p.ImgUrl,
                Date = p.Date,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                Speaker = p.Speaker,
                SpeakerImageUrl = p.SpeakerImageUrl,
                Status = p.Status,
                LocationType = p.LocationType,
                Location = p.Location
            });
        }

        // Lấy Communication Program theo ProgramID
        public async Task<CommunicationProgramDto?> GetByIdAsync(Guid programId)
        {
            var p = await _communicationProgramRepository.GetByIdAsync(programId);
            if (p == null) return null;
            return new CommunicationProgramDto
            {
                ProgramID = p.ProgramID,
                Name = p.Name,
                Description = p.Description,
                ImgUrl = p.ImgUrl,
                Date = p.Date,
                StartTime = p.StartTime,
                EndTime = p.EndTime,
                Speaker = p.Speaker,
                SpeakerImageUrl = p.SpeakerImageUrl,
                LocationType = p.LocationType,
                Location = p.Location
            };
        }
    }
}
