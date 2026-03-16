using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthenService
    {
        Task<RegisterResult> RegisterAsync(RegisterDto dto);
        Task<User?> LoginAsync(LoginDto dto);
        Task<User?> LoginWithGoogleAsync(GoogleLoginDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordRequestDto dto);
    }
}
