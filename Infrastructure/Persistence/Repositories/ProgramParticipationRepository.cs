using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProgramParticipationRepository : GenericRepository<ProgramParticipation>, IProgramParticipationRepository
    {
        public ProgramParticipationRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<ProgramParticipation?> GetByUserAndProgramAsync(Guid userId, Guid programId)
        {
            return await _context.ProgramParticipations
                .FirstOrDefaultAsync(p =>
                    p.UserID == userId &&
                    p.ProgramID == programId);
        }

        public async Task<List<ProgramParticipation>> GetByUserIdWithProgramAsync(Guid userId)
        {
            return await _dbSet
                .Include(p => p.CommunicationProgram)
                .Where(p => p.UserID == userId)
                .ToListAsync();
        }

        public async Task<List<ProgramParticipation>> GetByProgramIdWithUserAsync(Guid programId)
        {
            return await _dbSet
                .Include(p => p.User)
                .Where(p => p.ProgramID == programId)
                .ToListAsync();
        }
    }
}
