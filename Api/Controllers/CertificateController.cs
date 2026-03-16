using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly ICertificateService _certificateService;

        public CertificateController(ICertificateService certificateService)
        {
            _certificateService = certificateService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCertificateDto dto)
        {
            try
            {
                await _certificateService.CreateAsync(dto);
                return Ok(new { message = "Create successfully" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _certificateService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var result = await _certificateService.GetByIdAsync(id);
                return Ok(result);
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Certificate not found" });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool result = await _certificateService.DeleteAsync(id);
                return Ok(new { message = "Delete Successfully" });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Certificate not found" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCertificateDto dto)
        {
            try
            {
                var result = await _certificateService.UpdateAsync(id, dto);
                return Ok(new { message = "Update Successfully" });
            }
            catch(KeyNotFoundException ex)
            {
                return NotFound(new { message = "Certificate not found" });
            }
        }
    }
}
