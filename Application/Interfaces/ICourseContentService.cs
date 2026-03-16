using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICourseContentService
    {
        Task<List<CourseContentDto>> GetCourseContentsAsync(Guid courseId);
        Task<CourseContentDto> GetCourseContentByIdAsync(Guid id);
        Task<CourseContentDto?> CreateCourseContentAsync(Guid courseId, CreateCourseContentDto dto);
        Task<CourseContentDto?> UpdateCourseContentAsync(Guid id, UpdateCourseContentDto dto);
        Task<bool> DeleteCourseContentAsync(Guid id);
    }
}
