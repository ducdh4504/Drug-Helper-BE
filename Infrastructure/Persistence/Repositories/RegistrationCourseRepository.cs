using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class RegistrationCourseRepository : GenericRepository<CourseRegistration>, IRegistrationCourseRepository
    {
        public RegistrationCourseRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<bool> IsUserRegisteredAsync(Guid userId, Guid courseId)
        {
            return await _dbSet
                .AnyAsync(r => r.UserID == userId && r.CourseID == courseId);
        }
    }
}
