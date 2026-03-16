using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs
{
    public class UpdateAppointmentStatusDto
    {
        public Guid AppointmentId { get; set; }
        public AppointmentResponseEnum Status { get; set; }
    }

}
