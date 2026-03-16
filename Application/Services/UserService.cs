using System.Security.Claims;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }

        public Task<User> GetByEmailAsync(string email)
        {
            var user = _userRepository.GetByUsernameOrEmailAsync(email);
            return user;
        }
        public async Task<IEnumerable<User>> GetAllUser()
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role);
            var role = roleClaim?.Value;

            if(role != RoleEnum.Admin.ToString())
            {
                return null;
            }


            var userList = await _userRepository.GetAllAsync();
            return userList;
        }
        public async Task<UserProfileDto?> GetProfileAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new InvalidOperationException($"User with ID {userId} not found.");
            }

            return new UserProfileDto
            {
                UserID = user.UserID,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                ImgUrl = user.ImgUrl,
                Address = user.Address,
                Phone = user.Phone,
                Email = user.Email,
            };
        }

        public async Task<bool> UpdateProfileAsync(Guid userId, UpdateProfileDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.FullName))
                user.FullName = dto.FullName;

            if (dto.DateOfBirth.HasValue)
                user.DateOfBirth = dto.DateOfBirth.Value;

            if (!string.IsNullOrWhiteSpace(dto.Address))
                user.Address = dto.Address;
            if(!string.IsNullOrWhiteSpace(dto.ImgUrl))
                user.ImgUrl = dto.ImgUrl;
            if (!string.IsNullOrWhiteSpace(dto.Phone))
                user.Phone = dto.Phone;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateUserAsync(Guid userId, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return false;

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                user.UserName = dto.UserName;
            if (!string.IsNullOrWhiteSpace(dto.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            if (!string.IsNullOrWhiteSpace(dto.Email))
                user.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.ImgUrl))
                user.ImgUrl = dto.ImgUrl;
            if (!string.IsNullOrWhiteSpace(dto.FullName))
                user.FullName = dto.FullName;
            if (dto.DateOfBirth.HasValue)
                user.DateOfBirth = dto.DateOfBirth.Value;
            if (!string.IsNullOrWhiteSpace(dto.Address))
                user.Address = dto.Address;
            if (!string.IsNullOrWhiteSpace(dto.Phone))
                user.Phone = dto.Phone;
            if (dto.Role.HasValue)
                user.Role = dto.Role.Value;
            if (dto.Status.HasValue)
                user.Status = dto.Status.Value;

            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ConsultantDto>> GetAllConsultantsAsync()
        {
            try
            {
                var consultants = await _userRepository.GetActiveConsultantsWithCertificatesAsync();

                if(consultants == null || !consultants.Any())
                    throw new InvalidOperationException("No consultants found.");

                return consultants.Select(u => new ConsultantDto
                {
                    UserID = u.UserID,
                    UserName = u.UserName,
                    ImgUrl = u.ImgUrl,
                    Email = u.Email,
                    FullName = u.FullName,
                    Phone = u.Phone,
                    Address = u.Address,
                    DateOfBirth = u.DateOfBirth,
                    Role = u.Role.ToString(),
                    Status = u.Status.ToString(),
                    CertificateIds = u.Certificates?.Select(c => c.CertificateID).ToList() ?? new List<Guid>()
                });
            }
            catch (Exception)
            {
                // Có thể log lỗi tại đây nếu cần
                throw;
            }
        }

        public async Task<ConsultantDto?> GetConsultantByIdAsync(Guid consultantId)
        {
            var user = await _userRepository.GetUserWithCertificatesAsync(consultantId);
            if (user == null || user.Role != RoleEnum.Consultant || user.Status != ActivityStatusEnum.Active)
                return null;

            return new ConsultantDto
            {
                UserID = user.UserID,
                UserName = user.UserName,
                ImgUrl = user.ImgUrl,
                Email = user.Email,
                FullName = user.FullName,
                Phone = user.Phone,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
                Role = user.Role.ToString(),
                Status = user.Status.ToString(),
                CertificateIds = user.Certificates?.Select(c => c.CertificateID).ToList() ?? new List<Guid>()
            };
        }

        public async Task<User?> GetByIdAsync(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }

        public async Task<IDictionary<string, object>> GetUserAgeGroupStatisticsAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var now = DateTime.UtcNow;
            int total = users.Count();

            var groups = new Dictionary<string, int>
            {
                { "Under 18", 0 },
                { "18-25", 0 },
                { "26-35", 0 },
                { "36-45", 0 },
                { "46-60", 0 },
                { "Above 60", 0 },
                { "Unknown", 0 }
            };

            foreach (var user in users)
            {
                if (user.DateOfBirth.HasValue)
                {
                    var age = (int)((now - user.DateOfBirth.Value).TotalDays / 365.25);
                    if (age < 18) groups["Under 18"]++;
                    else if (age <= 25) groups["18-25"]++;
                    else if (age <= 35) groups["26-35"]++;
                    else if (age <= 45) groups["36-45"]++;
                    else if (age <= 60) groups["46-60"]++;
                    else groups["Above 60"]++;
                }
                else
                {
                    groups["Unknown"]++;
                }
            }

            var result = new Dictionary<string, object>();
            foreach (var group in groups)
            {
                double percent = total > 0 ? (double)group.Value * 100 / total : 0;
                result[group.Key] = new { count = group.Value, percent = percent };
            }
            result["Total"] = total;
            return result;
        }

        public async Task<User> CreateUserAsync(UpdateUserDto dto)
        {
            // Check for required fields
            if (string.IsNullOrWhiteSpace(dto.UserName) || string.IsNullOrWhiteSpace(dto.Password) || string.IsNullOrWhiteSpace(dto.Email))
                throw new ArgumentException("UserName, Password, and Email are required");

            // Check if username or email already exists
            if (await _userRepository.CheckUsernameExistsAsync(dto.UserName))
                throw new InvalidOperationException("Username already exists");
            if (await _userRepository.CheckEmailExistsAsync(dto.Email))
                throw new InvalidOperationException("Email already exists");

            var user = new User
            {
                UserID = Guid.NewGuid(),
                UserName = dto.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Email = dto.Email,
                ImgUrl = dto.ImgUrl,
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Phone = dto.Phone,
                Role = dto.Role ?? RoleEnum.Member,
                Status = dto.Status ?? ActivityStatusEnum.Active
            };
            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return user;
        }
    }
}
