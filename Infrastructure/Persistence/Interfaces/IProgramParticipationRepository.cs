using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IProgramParticipationRepository:IGenericRepository<ProgramParticipation>
    {
        Task<ProgramParticipation?> GetByUserAndProgramAsync(Guid userId, Guid programId);
        Task<List<ProgramParticipation>> GetByUserIdWithProgramAsync(Guid userId);
        Task<List<ProgramParticipation>> GetByProgramIdWithUserAsync(Guid programId);
    }
}
