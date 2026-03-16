using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class AppointmentDto
    {
        public Guid UserId { get; set; }
        public DateTime DateTime { get; set; }
        public AppointmentResponseEnum Status { get; set; }
        public string? Note { get; set; }
    }

}
