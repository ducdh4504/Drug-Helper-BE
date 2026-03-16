using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IRegistrationCourseRepository : IGenericRepository<CourseRegistration>
    {
        Task<bool> IsUserRegisteredAsync(Guid userId, Guid courseId);
    }
}
