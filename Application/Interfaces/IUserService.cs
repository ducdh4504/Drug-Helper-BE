using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);
        Task<UserProfileDto> GetProfileAsync(Guid dto);
        Task<bool> UpdateProfileAsync(Guid userId, UpdateProfileDto dto);
        Task<IEnumerable<User>> GetAllUser();
        Task<IEnumerable<ConsultantDto>> GetAllConsultantsAsync();
        Task<ConsultantDto?> GetConsultantByIdAsync(Guid consultantId);
        Task<User?> GetByIdAsync(Guid userId);
        Task<bool> UpdateUserAsync(Guid userId, UpdateUserDto dto);
        Task<IDictionary<string, object>> GetUserAgeGroupStatisticsAsync();
        Task<User> CreateUserAsync(UpdateUserDto dto);
    }
}
