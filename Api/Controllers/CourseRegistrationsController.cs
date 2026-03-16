using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseRegistrationsController : ControllerBase
    {
        private readonly ICourseRegistrationService _registrationService;
        public CourseRegistrationsController(ICourseRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCourseDto dto)
        {
            var result = await _registrationService.RegisterAsync(dto);
            if (result == null)
            {
                return BadRequest("User has registered for this course.");
            }

            return Ok(result);
        }

        [HttpGet("result")]
        public async Task<IActionResult> GetRegistrationResult([FromQuery] Guid userId, [FromQuery] Guid courseId)
        {
            var result = await _registrationService.GetRegistrationResultAsync(userId, courseId);
            if (result == null)
                return NotFound("Registration not found.");

            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetRegistrationsByUser([FromQuery] Guid userId)
        {
            var results = await _registrationService.GetRegistrationsByUserAsync(userId);
            if (results == null || !results.Any())
                return NotFound("No registrations found for this user.");

            return Ok(results);
        }
    }
}
