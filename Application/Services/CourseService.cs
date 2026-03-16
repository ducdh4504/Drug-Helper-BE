using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CourseDto> CreateAsync(CreateCourseDto dto)
        {
            var course = new Course
            {
                CourseID = Guid.NewGuid(),
                Title = dto.Title,
                ImgUrl = dto.ImgUrl,
                contentSummary = dto.ContentSummary,
                Description = dto.Description,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                AgeMin = dto.AgeMin,
                Capacity = dto.Capacity,
                ResultLevel = dto.ResultLevel
            };

            await _courseRepository.AddAsync(course);
            await _unitOfWork.SaveChangesAsync();

            return new CourseDto
            {
                CourseId = course.CourseID,
                Title = course.Title,
                ContentSummary = course.contentSummary,
                ImgUrl = course.ImgUrl,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                AgeMin = (int)course.AgeMin,
                Capacity = (int)course.Capacity,
                ResultLevel = course.ResultLevel
            };
        }

        public async Task<CourseDto?> UpdateAsync(Guid id, UpdateCourse dto)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return null;
            }

            course.Title = dto.Title;
            course.ImgUrl = dto.ImgUrl;
            course.contentSummary = dto.ContentSummary;
            course.Description = dto.Description;
            course.ImgUrl = dto.ImgUrl;
            course.StartDate = dto.StartDate;
            course.EndDate = dto.EndDate;
            course.Status = dto.Status;
            course.AgeMin = dto.AgeMin;
            course.Capacity = dto.Capacity;
            course.ResultLevel = dto.ResultLevel;

            await _unitOfWork.SaveChangesAsync();

            return new CourseDto
            {
                CourseId = course.CourseID,
                Title = course.Title,
                ContentSummary = course.contentSummary,
                ImgUrl = course.ImgUrl,
                Description = course.Description,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Status = course.Status,
                AgeMin = (int)course.AgeMin,
                Capacity = (int)course.Capacity,
                ResultLevel = course.ResultLevel
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var course = await _courseRepository.GetByIdAsync(id);

            if (course == null)
            {
                return false;
            }

            _courseRepository.Remove(course);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllAsync();
            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseID,
                Title = c.Title,
                ContentSummary = c.contentSummary,
                Description = c.Description ?? string.Empty,
                ImgUrl = c.ImgUrl,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Status = c.Status,
                AgeMin = c.AgeMin ?? 0,
                Capacity = c.Capacity ?? 0,
                ResultLevel = c.ResultLevel
            }).ToList();
        }

        public async Task<CourseDto?> GetByIdAsync(Guid courseId)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);

            if (course == null) return null;

            return new CourseDto
            {
                CourseId = course.CourseID,
                Title = course.Title,
                ContentSummary = course.contentSummary,
                ImgUrl = course.ImgUrl,
                Description = course.Description ?? string.Empty,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                Status = course.Status,
                AgeMin = course.AgeMin ?? 0,
                Capacity = course.Capacity ?? 0,
                ResultLevel = course.ResultLevel
            };
        }

        public async Task<IEnumerable<CourseDto>> SearchCoursesAsync(string searchTerm)
        {
            var courses = await _courseRepository.FindAsync(c =>
                c.Title.Contains(searchTerm) || (c.Description ?? "").Contains(searchTerm));
            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseID,
                Title = c.Title,
                ContentSummary = c.contentSummary,
                ImgUrl = c.ImgUrl,
                Description = c.Description ?? string.Empty,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Status = c.Status,
                AgeMin = c.AgeMin ?? 0,
                Capacity = c.Capacity ?? 0,
                ResultLevel = c.ResultLevel
            });
        }
    }
}
