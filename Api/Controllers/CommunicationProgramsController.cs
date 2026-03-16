using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff,Manager,Admin")]
    public class CommunicationProgramsController : ControllerBase
    {
        private readonly ICommunicationProgramService _communicationProgramService;

        public CommunicationProgramsController(ICommunicationProgramService communicationProgramService)
        {
            _communicationProgramService = communicationProgramService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommunicationProgramDto dto)
        {
            try
            {
                await _communicationProgramService.CreateAsync(dto);
                return Ok("Create Successfully");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCommunicationProgramDto dto)
        {
            try
            {
                var result = await _communicationProgramService.UpdateAsync(dto);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Communication Program not found" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid ProgramID)
        {
            try
            {
                var result = await _communicationProgramService.DeleteAsync(ProgramID);
                return Ok("Delete Successfully");
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Communication Program not found" });
            }
        }

        // API lấy danh sách Communication Program
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _communicationProgramService.GetAllAsync();
            return Ok(result);
        }

        // API lấy Communication Program theo ProgramID
        [HttpGet("{programId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid programId)
        {
            try
            {
                var result = await _communicationProgramService.GetByIdAsync(programId);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Communication Program not found" });
            }
        }
    }
}
