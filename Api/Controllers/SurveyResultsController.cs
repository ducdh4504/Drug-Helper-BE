using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyResultsController : ControllerBase
    {
        private readonly ISurveyResultService _surveyResultService;
        public SurveyResultsController(ISurveyResultService surveyResultService)
        {
            _surveyResultService = surveyResultService;
        }

        [HttpPut] 
        public async Task<IActionResult> Update([FromBody] UpdateSurveyResultDto dto)
        {
            try
            {
                var result = await _surveyResultService.UpdateSurveyResultAsync(dto);
                return Ok(new { result.SubmitTime });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Survey result not found"))
                    return NotFound(new { error = "Survey result not found." });

                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Update failed.", detail = ex.Message });
            }
        }

        [HttpGet("by-survey/{surveyId}")]
        public async Task<IActionResult> GetBySurvey(Guid surveyId)
        {
            var listSurveyResult = await _surveyResultService.GetByServeyIdAsync(surveyId);
            return Ok(listSurveyResult);
        }

        [HttpGet] 
        public async Task<IActionResult> GetByUserAndSurvey([FromQuery] Guid surveyid, [FromQuery] Guid programid)
        {
            var surveyResult = await _surveyResultService.GetBySurveyAndProgramIdAsync(surveyid, programid);
            if(surveyResult == null)
                return NotFound(new { message = "No data found" });
            return Ok(new { surveyResult.UserID, surveyResult.ResponseData, surveyResult.SubmitTime });
        }

        [HttpPost("link")]
        public async Task<IActionResult> LinkSurveyProgram([FromBody] CreateSurveyResultDto dto)
        {
            try
            {
                var result = await _surveyResultService.LinkSurveyProgramAsync(dto);
                if (result)
                    return Ok(new { message = "Link survey and program successfully." });
                return BadRequest(new { error = "Linking failed." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Linking failed.", detail = ex.Message });
            }
        }

        [HttpGet("by-program/{programId}")]
        public async Task<IActionResult> GetSurveyIdsByProgram(Guid programId)
        {
            try
            {
                var surveyIds = await _surveyResultService.GetSurveyIdsByProgramIdAsync(programId);
                return Ok(surveyIds);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Get survey ids failed.", detail = ex.Message });
            }
        }

        [HttpGet("count-by-program/{programId}")]
        public async Task<IActionResult> GetSurveyResultCountsByProgram(Guid programId)
        {
            try
            {
                var data = await _surveyResultService.GetSurveyResultCountsByProgramAsync(programId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Get survey result counts failed.", detail = ex.Message });
            }
        }
    }
}
