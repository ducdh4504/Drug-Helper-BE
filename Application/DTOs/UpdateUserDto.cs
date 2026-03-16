using System;

namespace Application.DTOs
{
    public class UpdateUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? ImgUrl { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public Domain.Enums.RoleEnum? Role { get; set; }
        public Domain.Enums.ActivityStatusEnum? Status { get; set; }
    }
}
