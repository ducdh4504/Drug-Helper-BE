using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICourseService
    {

        Task<IEnumerable<CourseDto>> SearchCoursesAsync(string searchTerm);

        Task<CourseDto> CreateAsync(CreateCourseDto dto);

        Task<CourseDto?> UpdateAsync(Guid id, UpdateCourse dto);

        Task<bool> DeleteAsync(Guid id);
        Task<List<CourseDto>> GetAllCoursesAsync();
        Task<CourseDto?> GetByIdAsync(Guid courseId);
    }

}
