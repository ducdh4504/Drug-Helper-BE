using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultantSchedulesController : ControllerBase
    {
        private readonly IConsultantScheduleService _scheduleService;
        private readonly IAppointmentService _appointmentService;

        public ConsultantSchedulesController(IConsultantScheduleService scheduleService, IAppointmentService appointmentService)
        {
            _scheduleService = scheduleService;
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateConsultantScheduleDto dto)
        {
            var result = await _scheduleService.CreateScheduleAsync(dto);
            if (result == null)
                return BadRequest("There is an error when create schedule");
            return Ok(result);
        }
       
        [HttpPut("{scheduleId}")]
        public async Task<IActionResult> UpdateSchedule(Guid scheduleId, [FromBody] UpdateConsultantScheduleDto dto)
        {
            var result = await _scheduleService.UpdateScheduleAsync(scheduleId, dto);
            return result ? Ok("Schedule updated successfully.") : NotFound("Schedule not found.");
        }

        [HttpDelete("{scheduleId}")]
        public async Task<IActionResult> Delete(Guid scheduleId)
        {
            var success = await _scheduleService.DeleteScheduleAsync(scheduleId);
            if (!success)
                return NotFound("Schedule not found.");

            return Ok("Schedule deleted successfully.");
        }

        [HttpGet("{consultantId}")]
        public async Task<IActionResult> GetSchedulesByConsultantId(Guid consultantId)
        {
            var schedules = await _scheduleService.GetSchedulesByConsultantIdAsync(consultantId);
            return Ok(schedules);
        }

        [HttpGet("schedule/{scheduleId}")]
        public async Task<IActionResult> GetScheduleById(Guid scheduleId)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(scheduleId);
            if (schedule == null)
                return NotFound("Schedule not found.");
            return Ok(schedule);
        }

        [HttpPost("link-appointment")]
        public async Task<IActionResult> LinkAppointment([FromQuery] Guid scheduleId, [FromQuery] Guid appointmentId)
        {
            var result = await _scheduleService.LinkAppointmentAsync(scheduleId, appointmentId);
            if (!result)
                return NotFound("Schedule not found.");
            return Ok("Linked appointment to schedule successfully.");
        }

        
    }
}
