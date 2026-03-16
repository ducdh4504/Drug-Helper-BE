using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConsultantScheduleRepository _consultantScheduleRepository;
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IUnitOfWork unitOfWork, IConsultantScheduleRepository consultantScheduleRepository, IAppointmentRepository appointmentRepository)
        {
            _unitOfWork = unitOfWork;
            _consultantScheduleRepository = consultantScheduleRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto)
        {
            var schedule = await _consultantScheduleRepository.GetByConsultantDateAndStartTimeAsync(dto.ConsultantId, dto.Date, dto.StartTime.TimeOfDay);
            if (schedule != null && schedule.IsAvailable)
            {
                throw new Exception("Consultant is available at this time. Please book through the schedule.");
            }

            var appointment = new Appointment
            {
                AppointmentID = Guid.NewGuid(),
                MemberID = dto.UserId,
                ConsultantID = dto.ConsultantId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Date = dto.Date,
                Status = AppointmentResponseEnum.NoResponseYet,
                Note = dto.Note
            };

            await _appointmentRepository.AddAsync(appointment);
            await _unitOfWork.SaveChangesAsync();

            return new AppointmentDto
            {
                UserId = dto.UserId,
                DateTime = dto.StartTime,
                Status = AppointmentResponseEnum.NoResponseYet,
                Note = dto.Note
            };
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
           return await _appointmentRepository.GetAllAsync();
        }

        public async Task<Appointment?> GetByIdAsync(Guid appointmentID)
        {
            return await  _appointmentRepository.GetByIdAsync(appointmentID);
        }

        public async Task<bool> UpdateStatusAsync(UpdateAppointmentStatusDto dto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(dto.AppointmentId);
            if(appointment == null)
                return false;
            appointment.Status = dto.Status; 
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Appointment>> GetByMemberIdAsync(Guid memberId)
        {
            var appointments = await _appointmentRepository.GetByMemberIdAsync(memberId);
            return appointments;
        }
    }
}
