using Application.DTOs;
using Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenService _authenService;
        private readonly IValidator<RegisterDto> _validator;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(IAuthenService authenService, IValidator<RegisterDto> validator, IJwtService jwtService, IUserService userService)
        {
            _authenService = authenService;
            _validator = validator;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            var result = await _authenService.RegisterAsync(dto);

            if (!result.Success)
            {
                var errors = new List<object>();
                if (result.EmailNotReal)
                    errors.Add(new { Field = "Email", Error = "Email is not real" });
                if (result.EmailExists)
                    errors.Add(new { Field = "Email", Error = "Email has already existed in the system" });
                if (result.UsernameExists)
                    errors.Add(new { Field = "Username", Error = "Username has already existed in the system" });

                if (errors.Count > 0)
                    return BadRequest(errors);
            }

            return Ok("Registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _authenService.LoginAsync(dto);

            if (user == null)
                return Unauthorized(new { message = "Invalid credentials" });

            string token = _jwtService.GenerateToken(user);

            return Ok(new { token });
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDto dto)
        {
            var user = await _authenService.LoginWithGoogleAsync(dto);

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid Google credentials" });
            }

            string token = _jwtService.GenerateToken(user);
            return Ok(new { user, token });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = await _authenService.ResetPasswordAsync(dto);

            if (!success)
                return BadRequest(new { message = "There is a error in process of resetting password" });

            return Ok(new { message = "Reseting password successfully" });
        }

    }
}
