using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Phương thức tạo token đăng nhập
        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            return CreateJwtToken(claims, DateTime.UtcNow.AddDays(1));
        }

        // Phương thức mới cho reset password
        public string GenerateResetPasswordToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim("reset", "true") // Claim đặc biệt cho reset password
            };

            return CreateJwtToken(
                claims,
                DateTime.UtcNow.AddMinutes(GetResetTokenExpiryMinutes())
            );
        }

        private string CreateJwtToken(Claim[] claims, DateTime expires)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
            );

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private int GetResetTokenExpiryMinutes()
        {
            return int.TryParse(
                _configuration["Jwt:ResetPasswordTokenExpiryMinutes"],
                out var minutes
            ) ? minutes : 60;
        }
    }
}
