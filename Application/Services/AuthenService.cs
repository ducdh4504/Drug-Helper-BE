using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using FirebaseAdmin.Auth;
using Google.Apis.Auth;
using Infrastructure.Persistence.Interfaces;

namespace Application.Services
{
    public class AuthenService : IAuthenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;

        public AuthenService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterDto dto)
        {
            var result = new RegisterResult();

            // 1. Kiểm tra email đã xác thực trên Firebase
            UserRecord userRecord;
            try
            {
                userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(dto.Email);
            }
            catch
            {
                result.Success = false;
                result.EmailNotReal = true;
                result.Message = "Email is not real";
                return result;
            }

            // 2. Kiểm tra email và username đã tồn tại trong DB
            if (await _userRepository.CheckEmailExistsAsync(dto.Email))
                result.EmailExists = true;

            if (await _userRepository.CheckUsernameExistsAsync(dto.Username))
                result.UsernameExists = true;

            if (result.EmailExists || result.UsernameExists)
            {
                result.Success = false;
                result.Message = "Email or Username has already existed.";
                return result;
            }

            // 3. Hash password và lưu user vào DB
            var user = new User
            {
                UserID = Guid.NewGuid(),
                UserName = dto.Username,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                DateOfBirth = dto.Birthday
            };

            await _userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            result.Success = true;
            result.Message = "Registration successful";
            return result;
        }


        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(dto.UsernameOrEmail);

            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

            return isValid ? user : null;
        }

        public async Task<User?> LoginWithGoogleAsync(GoogleLoginDto dto)
        {
            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(dto.IdToken);

                var user = await _userRepository.GetByUsernameOrEmailAsync(payload.Email);

                if (user == null)
                {
                    user = new User
                    {
                        UserID = Guid.NewGuid(),
                        UserName = payload.Name,
                        Email = payload.Email,
                        FullName = payload.Name,
                    };
                    await _userRepository.AddAsync(user);
                    await _unitOfWork.SaveChangesAsync();
                }
                return user;
            }
            catch (InvalidJwtException)
            {
                return null;
            }
        }

        public async Task<bool> ResetPasswordAsync(ResetPasswordRequestDto dto)
        {
            var user = await _userRepository.GetByUsernameOrEmailAsync(dto.Email);
            if (user == null) return false;

            user.Password = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();

            // Cập nhật password trên Firebase
            var userRecord = await FirebaseAuth.DefaultInstance.GetUserByEmailAsync(dto.Email);
            var args = new UserRecordArgs()
            {
                Uid = userRecord.Uid,
                Password = dto.NewPassword
            };
            await FirebaseAuth.DefaultInstance.UpdateUserAsync(args);

            return true;
        }


    }
}
