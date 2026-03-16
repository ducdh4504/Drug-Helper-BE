using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> Create([FromBody] CreateBlogDto dto)
        {
            try
            {
                var blog = await _blogService.CreateBlogAsync(dto);
                return Ok(blog);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            try
            {
                var blogs = await _blogService.GetAllBlogsAsync();
                return Ok(blogs);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = "There is an error when striving to get blog list.", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var blog = await _blogService.GetBlogByIdAsync(id);
                return Ok(blog);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new {message= "Blog not found" });
            }
        }

        [HttpPut]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> Update([FromBody] UpdateBlogDto dto)
        {
            try
            {
                var result = await _blogService.UpdateBlogAsync(dto);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Blog not found" });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Staff")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _blogService.DeleteBlogAsync(id);
                return Ok("Blog deleted successfully");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Blog not found" });
            }
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchByTitle([FromQuery] string keyword)
        {
            var blogs = await _blogService.SearchBlogsByTitleAsync(keyword);
            return Ok(blogs);
        }
    }
}
