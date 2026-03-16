using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICourseRegistrationService
    {
        Task<CourseRegistrationResultDto?> RegisterAsync(RegisterCourseDto dto);
        Task<CourseRegistrationResultDto?> GetRegistrationResultAsync(Guid userId, Guid courseId);
        Task<List<CourseRegistrationResultDto>> GetRegistrationsByUserAsync(Guid userId);
    }
}
