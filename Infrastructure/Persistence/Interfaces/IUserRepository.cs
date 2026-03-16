using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> CheckEmailExistsAsync(string email);
        Task<bool> CheckUsernameExistsAsync(string username);
        Task<User?> GetByUsernameOrEmailAsync(string username);
        Task<User?> GetUserWithCertificatesAsync(Guid userId);
        Task<List<User>> GetActiveConsultantsWithCertificatesAsync();
    }
}
