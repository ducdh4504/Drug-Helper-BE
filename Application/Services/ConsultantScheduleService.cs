using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class ConsultantScheduleService : IConsultantScheduleService
    {
        private readonly IConsultantScheduleRepository _scheduleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConsultantScheduleService(IConsultantScheduleRepository scheduleRepository, IUnitOfWork unitOfWork)
        {
            _scheduleRepository = scheduleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ConsultantScheduleDto> CreateScheduleAsync(CreateConsultantScheduleDto dto)
        {
            if(dto.StartTime >= dto.EndTime)
            {
                throw new Exception("Start time must be earlier than end time.");
            }
            // Tìm lịch cùng consultant, cùng date
            var existingSchedules = await _scheduleRepository
                .GetByConsultantAndDateAsync(dto.ConsultantId, dto.Date);

            // Kiểm tra xem có xung đột không
            bool hasConflict = existingSchedules.Any(s =>
                dto.StartTime < s.EndTime && dto.EndTime > s.StartTime);

            if(hasConflict)
            {
                throw new Exception("The new schedule overlaps with an existing schedule.");
            }
            // Không xung đột => tạo mới
            var schedule = new ConsultantSchedule
            {
                ConsultantScheduleID = Guid.NewGuid(),
                UserID = dto.ConsultantId,
                DayOfWeek = dto.DayOfWeek,
                Date = dto.Date,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Notes = dto.Notes,
                IsAvailable = false
            };

            await _scheduleRepository.AddAsync(schedule);
            await _unitOfWork.SaveChangesAsync();

            return new ConsultantScheduleDto
            {
                ConsultantScheduleID = schedule.ConsultantScheduleID,
                DayOfWeek = schedule.DayOfWeek,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable,
                Notes = schedule.Notes
            };
        }

        public async Task<bool> UpdateScheduleAsync(Guid scheduleId, UpdateConsultantScheduleDto dto)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null) return false;

            schedule.DayOfWeek = dto.DayOfWeek;
            schedule.StartTime = dto.StartTime;
            schedule.EndTime = dto.EndTime;
            schedule.Notes = dto.Notes;
            schedule.Date = dto.Date;
            schedule.UserID = dto.ConsultantId;

            _scheduleRepository.Update(schedule);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteScheduleAsync(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null) return false;

            _scheduleRepository.Remove(schedule);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ConsultantScheduleDto>> GetSchedulesByConsultantIdAsync(Guid consultantId)
        {
            var schedules = await _scheduleRepository.FindAsync(s => s.UserID == consultantId);
            return schedules.Select(s => new ConsultantScheduleDto
            {
                ConsultantScheduleID = s.ConsultantScheduleID,
                DayOfWeek = s.DayOfWeek,
                Date = s.Date,
                StartTime = s.StartTime,
                EndTime = s.EndTime,
                IsAvailable = s.IsAvailable,
                Notes = s.Notes
            });
        }

        public async Task<ConsultantScheduleDto?> GetScheduleByIdAsync(Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null) return null;

            return new ConsultantScheduleDto
            {
                ConsultantScheduleID = schedule.ConsultantScheduleID,
                DayOfWeek = schedule.DayOfWeek,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                IsAvailable = schedule.IsAvailable,
                Notes = schedule.Notes
            };
        }

        public async Task<bool> LinkAppointmentAsync(Guid scheduleId, Guid appointmentId)
        {
            var schedule = await _scheduleRepository.GetByIdAsync(scheduleId);
            if (schedule == null)
                return false;
            schedule.AppointmentID = appointmentId;
            schedule.IsAvailable = false;
            _scheduleRepository.Update(schedule);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
