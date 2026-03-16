using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.DTOs
{
    public class ProgramParticipationInfoDto
    {
        public Guid UserID { get; set; }
        public Guid ProgramID { get; set; }
        public DateTime JoinTime { get; set; }
        public ActivityStatusEnum Status { get; set; }
    }

}
