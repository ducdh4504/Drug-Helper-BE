using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class CourseContentService : ICourseContentService
    {
        private readonly ICourseContentRepository _courseContentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseRepository _courseRepository;

        public CourseContentService(ICourseContentRepository courseContentRepository, IUnitOfWork unitOfWork, ICourseRepository courseRepository)
        {
            _courseContentRepository = courseContentRepository;
            _unitOfWork = unitOfWork;
            _courseRepository = courseRepository;
        }

        public async Task<CourseContentDto?> CreateCourseContentAsync(Guid courseId, CreateCourseContentDto dto)
        {
            var course = await _courseRepository.GetByIdAsync(courseId);
            if(course == null)
            {
                return null;
            }
            var entity = new CourseContent
            {
                CourseContentID = Guid.NewGuid(),
                Title = dto.Title,
                Content = dto.Content,
                Course = course
            };

            await _courseContentRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return new CourseContentDto
            {
                Title = entity.Title,
                Content = entity.Content,
            };
        }

        public async Task<bool> DeleteCourseContentAsync(Guid id)
        {
            var entity = await _courseContentRepository.GetByIdAsync(id);
            if (entity == null)
                return false;

            _courseContentRepository.Remove(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<CourseContentDto> GetCourseContentByIdAsync(Guid id)
        {
            var entity = await _courseContentRepository.GetByIdAsync(id);
            if (entity == null)
                return null!;

            return new CourseContentDto
            {
                Title = entity.Title,
                Content = entity.Content
            };
        }

        public async Task<List<CourseContentDto>> GetCourseContentsAsync(Guid courseId)
        {
            var entities = await _courseContentRepository.FindAsync(x => x.Course.CourseID == courseId);
            return entities
                .Select(x => new CourseContentDto
                {
                    CourseContentID = x.CourseContentID,
                    Title = x.Title,
                    Content = x.Content
                })
                .ToList();
        }

        public async Task<CourseContentDto?> UpdateCourseContentAsync(Guid id, UpdateCourseContentDto dto)
        {
            var entity = await _courseContentRepository.GetByIdAsync(id);
            if (entity == null)
                return null;

            entity.Title = dto.Title;
            entity.Content = dto.Content;

            _courseContentRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return new CourseContentDto
            {
                CourseContentID = id,
                Title = entity.Title,
                Content = entity.Content
            };
        }
    }
}
