using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
           return await _dbSet.AnyAsync(u => u.Email == email);
        }

        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
           return await _dbSet.AnyAsync(u => u.UserName == username);
        }

        public async Task<User?> GetByUsernameOrEmailAsync(string usernameOrEmail)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.UserName == usernameOrEmail
                                                    || u.Email == usernameOrEmail);
                   
        }

        public async Task<List<User>> GetActiveConsultantsWithCertificatesAsync()
        {
            return await _dbSet
                .Where(u => u.Role == Domain.Enums.RoleEnum.Consultant
                         && u.Status == Domain.Enums.ActivityStatusEnum.Active)
                .Include(u => u.Certificates)
                .ToListAsync();
        }

        public async Task<User?> GetUserWithCertificatesAsync(Guid userId)
        {
            return await _dbSet
                .Where(u => u.UserID == userId)
                .Include(u => u.Certificates)
                .FirstOrDefaultAsync();
        }

    }
}
