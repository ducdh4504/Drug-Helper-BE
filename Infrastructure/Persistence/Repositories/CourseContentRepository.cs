using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class CourseContentRepository : GenericRepository<CourseContent>, ICourseContentRepository
    {
        public CourseContentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
