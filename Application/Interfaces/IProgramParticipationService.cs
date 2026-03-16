using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProgramParticipationService
    {
        Task<DateTime?> RegisterAsync(RegisterProgramDto dto);
        Task<List<ProgramParticipationInfoDto>> GetByUserIdAsync(Guid userId);
        Task<ProgramParticipation?> GetByUserAndProgramAsync(Guid userId, Guid programId);
        Task<bool> UpdateStatusAsync(UpdateParticipationStatusDto dto);
        Task<List<ProgramParticipationInfoDto>> GetByProgramIdAsync(Guid programId);
    }
}
