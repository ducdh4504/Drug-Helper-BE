using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
        {
            try
            {
                var result = await _questionService.CreateQuestionAsync(dto);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return NotFound(new { message = "Create Failed" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var result = await _questionService.GetAllQuestionsAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _questionService.DeleteQuestionAsync(id);
            if(!result)
            {
                return NotFound(new { message = "Question not found" });
            }
            return Ok(new { message = "Deleted Successfully" });


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateQuestionDto dto)
        {
            var result = await _questionService.UpdateAsync(id, dto);
            if(result == null)
            {
                return NotFound(new { message = "Question not found" });
            }
            return Ok(result);
        }

    }
}
