using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentsController : ControllerBase
    {
        private readonly IAssessmentService _assessmentService;
        private readonly IAssessmentResultRepository _assessmentResultRepository;
        private readonly IAssessmentQuestionService _assessmentQuestionService;

        public AssessmentsController(
            IAssessmentService assessmentService,
            IAssessmentResultRepository assessmentResultRepository,
            IAssessmentQuestionService assessmentQuestionService)
        {
            _assessmentService = assessmentService;
            _assessmentResultRepository = assessmentResultRepository;
            _assessmentQuestionService = assessmentQuestionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _assessmentService.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var assessment = await _assessmentService.GetByIdAsync(id);
            if (assessment == null)
                return NotFound(new {message= "Assessment not found" });

            return Ok(assessment);
        }

        [Authorize(Roles = "Staff")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateAssessmentDto dto)
        {
            var success = await _assessmentService.CreateAssessmentAsync(dto);
            return success
                ? Ok("Assessment created successfully.")
                : Forbid("Only staff can create assessments.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAssessmentDto dto)
        {
            var result = await _assessmentService.UpdateAssessmentAsync(id, dto);
            if (!result)
                return NotFound("Assessment does not exist");

            return Ok("Assessment update successful");
        }

        [HttpPost("submit")]
        public async Task<IActionResult> Submit([FromBody] SubmitAssessmentDto dto)
        {
            if (dto == null || dto.Answers == null || !dto.Answers.Any())
                return BadRequest("Invalid assessment submission data.");
            var result = await _assessmentService.SubmitAsync(dto);

            return Ok(result);
        }

        [HttpGet("result")]
        public async Task<IActionResult> GetUserResult([FromQuery] Guid resultId)
        {
            var result = await _assessmentResultRepository.GetByIdAsync(resultId);

            if (result == null)
                return NotFound(new { message = "Result not found" });

            return Ok(new AssessmentResultDto
            {
                Score = result.Score,
                ResultLevel = result.ResultLevel
            });
        }

        [HttpPost("link-question")]
        public async Task<ActionResult<AssessmentQuestionResponseDto>> LinkQuestionToAssessment(
           [FromBody] AssessmentQuestionRequestDto request)
        {
            try
            {
                var result = await _assessmentQuestionService.LinkQuestionToAssessmentAsync(request);
                if (result.TotalQuestionsLinked == 0)
                    return BadRequest("No questions were linked.");
                return Ok("Linked successfully");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpPost("{assessmentId}/link-random-questions")]
        public async Task<ActionResult<AssessmentQuestionResponseDto>> LinkRandomQuestionsToAssessment(
            Guid assessmentId,
            [FromQuery] int questionCount = 1)
        {
            try
            {
                if (questionCount <= 0 || questionCount > 50)
                {
                    return BadRequest("Number of questions must be from 1 to 50");
                }

                var result = await _assessmentQuestionService.LinkRandomQuestionsToAssessmentAsync(assessmentId, questionCount);
                if (result.TotalQuestionsLinked == 0)
                    return BadRequest("No questions were linked.");
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }

        [HttpDelete("{assessmentId}/question/{questionId}")]
        public async Task<IActionResult> RemoveQuestionFromAssessment(Guid assessmentId, Guid questionId)
        {
            var result = await _assessmentQuestionService.RemoveQuestionFromAssessmentAsync(assessmentId, questionId);
            if (!result)
                return NotFound("The link between assessment and question does not exist.");
            return Ok("Link removed successfully.");
        }

        /// <summary>
        /// Recommend courses and blogs for a user based on their result level for each assessment.
        /// </summary>
        /// <param name="result">Result ID</param>
        /// <returns>List of recommendations grouped by assessment</returns>
        [HttpGet("recommend")]
        public async Task<IActionResult> Recommend([FromQuery] Guid resultId)
        {
            var recommendations = await _assessmentService.GetRecommendationsAsync(resultId);

            if (!recommendations.Any())
                return NotFound("No assessment results found for this user.");

            return Ok(recommendations);
        }
    }
}
