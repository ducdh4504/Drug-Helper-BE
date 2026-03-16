using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateCertificateDto
    {
        public string? ImgUrl { get; set; }
        public string? CertificateName { get; set; }
        public DateTime? DateAcquired { get; set; }
        public ActivityStatusEnum Status { get; set; } = ActivityStatusEnum.Active;
    }
}
