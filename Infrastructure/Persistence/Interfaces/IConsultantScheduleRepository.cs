using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IConsultantScheduleRepository : IGenericRepository<ConsultantSchedule>
    {
        Task<List<ConsultantSchedule>> GetByConsultantAndDateAsync(Guid consultantId, DateTime date);
        Task<ConsultantSchedule?> GetFirstAvailableSlotAsync(DateTime date, TimeSpan startTime);
        Task<ConsultantSchedule?> GetByConsultantDateAndStartTimeAsync(Guid consultantId, DateTime date, TimeSpan startTime);
    }
}
