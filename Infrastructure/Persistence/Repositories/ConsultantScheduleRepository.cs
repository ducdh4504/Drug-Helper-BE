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
    public class ConsultantScheduleRepository : GenericRepository<ConsultantSchedule>, IConsultantScheduleRepository
    {
        public ConsultantScheduleRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<List<ConsultantSchedule>> GetByConsultantAndDateAsync(Guid consultantId, DateTime date)
        {
            return await _dbSet
                .Where(s => s.UserID == consultantId && s.Date.Date == date.Date)
                .ToListAsync();
        }

        public async Task<ConsultantSchedule?> GetFirstAvailableSlotAsync(DateTime date, TimeSpan startTime)
        {
            return await _dbSet
                .Where(s => s.IsAvailable)
                .OrderBy(s => s.Date)
                .ThenBy(s => s.StartTime)
                .FirstOrDefaultAsync();
        }

        public async Task<ConsultantSchedule?> GetByConsultantDateAndStartTimeAsync(Guid consultantId, DateTime date, TimeSpan startTime)
        {
            return await _context.ConsultantSchedules
                .FirstOrDefaultAsync(s => s.UserID == consultantId && s.Date.Date == date.Date && s.StartTime == startTime);
        }
    }
}
