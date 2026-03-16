using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterProgramDto
    {
        public Guid UserId { get; set; }
        public Guid ProgramId { get; set; }
    }

}
