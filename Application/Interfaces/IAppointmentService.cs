using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);
        Task<Appointment?> GetByIdAsync(Guid appointmentID);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<bool> UpdateStatusAsync(UpdateAppointmentStatusDto dto);
        Task<IEnumerable<Appointment>> GetByMemberIdAsync(Guid memberId);
    }
}
