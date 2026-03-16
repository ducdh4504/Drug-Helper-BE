using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ICourseContentService _courseContentService;

        public CoursesController(ICourseService courseService, ICourseContentService courseContentService)
        {
            _courseService = courseService;
            _courseContentService = courseContentService;
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await _courseService.SearchCoursesAsync(term);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
        {
            var created = await _courseService.CreateAsync(dto);
            if(created == null)
            {
                return BadRequest(new { message = "There is an error when create schedule" });
            }
            return Ok(created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCourse dto)
        {
            try
            {
                var updated = await _courseService.UpdateAsync(id, dto);
                return Ok(updated);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var deleted = await _courseService.DeleteAsync(id);
                return Ok("Deleted successfully");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CourseDto>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var course = await _courseService.GetByIdAsync(id);
                return Ok(course);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }

        [HttpGet("{courseId}/contents")]
        public async Task<IActionResult> GetCourseContents(Guid courseId)
        {
            var contents = await _courseContentService.GetCourseContentsAsync(courseId);
            return Ok(contents);
        }

        [HttpPost("{courseId}/contents")]
        public async Task<IActionResult> CreateCourseContent(Guid courseId, [FromBody] CreateCourseContentDto dto)
        {
            try
            {
                var created = await _courseContentService.CreateCourseContentAsync(courseId, dto);
                return Ok(created);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }

        [HttpPut("contents/{id}")]
        public async Task<IActionResult> UpdateCourseContent(Guid id, [FromBody] UpdateCourseContentDto dto)
        {
            try
            {
                var updated = await _courseContentService.UpdateCourseContentAsync(id, dto);
                return Ok(updated);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }

        [HttpDelete("contents/{id}")]
        public async Task<IActionResult> DeleteCourseContent(Guid id)
        {
            try
            {
                var deleted = await _courseContentService.DeleteCourseContentAsync(id);
                return Ok("Deleted successfully");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Course not found" });
            }
        }
    }
}
