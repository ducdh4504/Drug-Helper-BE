using System;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto)
        {
            try
            {
                var result = await _appointmentService.CreateAsync(dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{appointmentID}")]
        public async Task<IActionResult> GetById(Guid appointmentID)
        {  
            try
            {
                var appointment = await _appointmentService.GetByIdAsync(appointmentID);
                    return Ok(new
                    {
                        appointment.AppointmentID,
                        appointment.MemberID,
                        appointment.ConsultantID,
                        appointment.Date,
                        appointment.StartTime,
                        appointment.EndTime,
                        appointment.Status,
                        appointment.Note
                    });
                }
            catch(KeyNotFoundException ex) {
                return NotFound(new { message = "Appointment not found" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listAppointments = await _appointmentService.GetAllAsync();
            return Ok(listAppointments.Select(appointment => new
            {
                appointment.AppointmentID,
                appointment.MemberID,
                appointment.ConsultantID,
                appointment.Date,
                appointment.StartTime,
                appointment.EndTime,
                appointment.Status,
                appointment.Note
            }));
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateAppointmentStatusDto dto)
        {
            try
            {
                await _appointmentService.UpdateStatusAsync(dto);
                return Ok(new { message = "Update successful" });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Appointment not found" });
            }
        }

        [HttpGet("by-member/{memberId}")]
        public async Task<IActionResult> GetByMemberId(Guid memberId)
        {
            var appointments = await _appointmentService.GetByMemberIdAsync(memberId);
            if (appointments == null || !appointments.Any())
                return NotFound(new { message = "No appointments found for this member" });
            var result = appointments.Select(appointment => new
            {
                appointment.AppointmentID,
                appointment.MemberID,
                appointment.ConsultantID,
                appointment.Date,
                appointment.StartTime,
                appointment.EndTime,
                appointment.Status,
                appointment.Note
            });
            return Ok(result);
        }

        [HttpGet("by-consultant/{consultantId}")]
        public async Task<IActionResult> GetByConsultantId(Guid consultantId)
        {
            var appointments = await _appointmentService.GetAllAsync();
            var result = appointments.Where(a => a.ConsultantID == consultantId).Select(appointment => new
            {
                appointment.AppointmentID,
                appointment.MemberID,
                appointment.ConsultantID,
                appointment.Date,
                appointment.StartTime,
                appointment.EndTime,
                appointment.Status,
                appointment.Note
            });
            return Ok(result);
        }
    }
}
