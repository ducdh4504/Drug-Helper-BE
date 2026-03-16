using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegisterCourseDto
    {
        public Guid UserID { get; set; }
        public Guid CourseID { get; set; }
    }
}
