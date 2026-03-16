using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpPost("create")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> CreateSurvey([FromBody] CreateSurveyDto dto)
        {
            var result = await _surveyService.CreateSurveyAsync(dto);
            if (!result) return BadRequest("Failed to create survey.");
            return Ok("Survey created successfully.");
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();
            return Ok(surveys);
        }
        [HttpGet("{surveyId}")]
        public async Task<IActionResult> GetSurveyById(Guid surveyId)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(surveyId);
            if (survey == null) return NotFound("Survey not found");

            return Ok(survey);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSurvey([FromBody] UpdateSurveyDto dto)
        {
            var result = await _surveyService.UpdateSurveyAsync(dto);
            if (result == null)
                return NotFound("Survey not found");

            return Ok(result);
        }
        [HttpDelete("{surveyId}")]
        public async Task<IActionResult> DeleteSurvey(Guid surveyId)
        {
            var success = await _surveyService.DeleteSurveyAsync(surveyId);
            if (!success)
                return NotFound(new { message = "Survey not found." });

            return Ok(new { message = "Survey deleted successfully." });
        }
    }
}
