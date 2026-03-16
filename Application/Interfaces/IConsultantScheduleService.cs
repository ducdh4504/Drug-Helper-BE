using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IConsultantScheduleService
    {
        Task<ConsultantScheduleDto> CreateScheduleAsync(CreateConsultantScheduleDto dto);
        Task<bool> UpdateScheduleAsync(Guid scheduleId, UpdateConsultantScheduleDto dto); 
        Task<bool> DeleteScheduleAsync(Guid scheduleId);
        Task<IEnumerable<ConsultantScheduleDto>> GetSchedulesByConsultantIdAsync(Guid consultantId);
        Task<ConsultantScheduleDto?> GetScheduleByIdAsync(Guid scheduleId);
        Task<bool> LinkAppointmentAsync(Guid scheduleId, Guid appointmentId);
    }
}
