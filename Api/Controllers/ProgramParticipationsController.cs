using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramParticipationsController : ControllerBase
    {
        private readonly IProgramParticipationService _programParticipationService;

        public ProgramParticipationsController(IProgramParticipationService programParticipationService)
        {
            _programParticipationService = programParticipationService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterProgramDto dto)
        {
            try
            {
                var result = await _programParticipationService.RegisterAsync(dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                if(ex.Message.Contains("User has registered for this program"))
                    return Conflict(new { error = "User has already registered for this program." });

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Registration failed.", detail = ex.Message });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId)
        {
            var result = await _programParticipationService.GetByUserIdAsync(userId);
            return Ok(result);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetParticipationInfo([FromQuery] Guid userId, [FromQuery] Guid programId)
        {
            var result = await _programParticipationService.GetByUserAndProgramAsync(userId, programId);
            if(result == null)
                return NotFound(new { message = "Participation not found" });
            return Ok(new
            {
                result.JoinTime,
                result.Status
            });
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromBody] UpdateParticipationStatusDto dto)
        {
            var result = await _programParticipationService.UpdateStatusAsync(dto);
            if(!result)
            {
                return NotFound(new { message = "Participation not found" });
            }
            return Ok(new { message = "Update Successfully" });


        }

        [HttpGet("by-program/{programId}")]
        public async Task<IActionResult> GetByProgram(Guid programId)
        {
            var result = await _programParticipationService.GetByProgramIdAsync(programId);
            return Ok(result);
        }
    }

}
