using Domain.Enums;
using System;

namespace Domain.Entities
{
    public class Certificate
    {
        public Guid CertificateID { get; set; }
        public Guid UserID { get; set; }
        public string? ImgUrl { get; set; }
        public string? CertificateName { get; set; }
        public DateTime? DateAcquired { get; set; }
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;

        // Navigation
        public User User { get; set; } = null!;
    }
}
