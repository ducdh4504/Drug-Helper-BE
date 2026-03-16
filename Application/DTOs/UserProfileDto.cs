using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserProfileDto
    {
        public Guid UserID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? ImgUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
    }
}
