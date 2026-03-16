using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public UserController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<IActionResult> GetProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!Guid.TryParse(userId, out var guid))
                return Unauthorized();

            var profile = await _userService.GetProfileAsync(guid);
            if (profile == null)
                return NotFound("User not found");
            return Ok(profile);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Lấy ID từ token
            if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guid))
                return Unauthorized("Invalid user ID");

            var success = await _userService.UpdateProfileAsync(guid, dto);

            if (!success)
                return NotFound("User not found");

            return Ok(new { message = "Profile updated successfully" });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var userList = await _userService.GetAllUser();
            return Ok(userList.Select(e => new
            {
                e.UserID,
                e.UserName,
                e.Email,
                e.ImgUrl,
                e.FullName,
                e.Phone,
                e.Address,
                e.DateOfBirth,
                e.Role,
                e.Status
            }));
        }

        [HttpGet("consultants")]
        public async Task<IActionResult> GetAllConsultants()
        {
            try
            {
                var consultants = await _userService.GetAllConsultantsAsync();
                return Ok(consultants);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Server error: " + ex.Message });
            }
        }

        [HttpGet("consultants/{consultantId}")]
        public async Task<IActionResult> GetConsultantById(Guid consultantId)
        {
            var consultant = await _userService.GetConsultantByIdAsync(consultantId);
            if (consultant == null)
                return NotFound("Consultant not found");
            return Ok(consultant);
        }

        [HttpGet("{userId:guid}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return NotFound("User not found");
            return Ok(new
            {
                user.UserID,
                user.UserName,
                user.Email,
                user.ImgUrl,
                user.FullName,
                user.Phone,
                user.Address,
                user.DateOfBirth,
                user.Role,
                user.Status
            });
        }

        [HttpGet("author/{userId:guid}")]
        public async Task<IActionResult> GetAuthorNameByUserId(Guid userId)
        {
            var user = await _userService.GetByIdAsync(userId);
            if (user == null)
                return BadRequest("User not found");
            return Ok(new { fullName = user.FullName });
        }

        [HttpPut("{userId:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserDto dto)
        {
            var success = await _userService.UpdateUserAsync(userId, dto);
            if (!success)
                return NotFound("User not found");
            return Ok(new { message = "User updated successfully" });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] UpdateUserDto dto)
        {
            try
            {
                var user = await _userService.CreateUserAsync(dto);
                return Ok(new
                {
                    user.UserID,
                    user.UserName,
                    user.Email,
                    user.ImgUrl,
                    user.FullName,
                    user.Phone,
                    user.Address,
                    user.DateOfBirth,
                    user.Role,
                    user.Status
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpGet("statistics/age-groups")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetUserAgeGroupStatistics()
        {
            try
            {
                var stats = await _userService.GetUserAgeGroupStatisticsAsync();
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Cannot get age group statistics.", detail = ex.Message });
            }
        }
    }
}

