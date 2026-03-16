using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence
{
    /// <summary>
    /// Implementation của UnitOfWork sử dụng ApplicationDbContext để quản lý transaction.
    /// Khi gọi CommitAsync, tất cả các thay đổi (thêm, sửa, xóa) 
    /// từ các repository được commit đồng bộ vào database.
    /// Giúp đảm bảo tính nhất quán dữ liệu và dễ dàng rollback khi có lỗi.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
