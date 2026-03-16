using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class ConsultantDto
    {
        public Guid UserID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public List<Guid> CertificateIds { get; set; } = new();
    }
}
