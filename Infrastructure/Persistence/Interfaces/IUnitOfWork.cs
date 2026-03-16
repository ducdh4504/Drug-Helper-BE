using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Interfaces
{
    /// <summary>
    /// Interface UnitOfWork giúp quản lý transaction.
    /// Cho phép gom nhiều thao tác với các repository khác nhau
    /// vào cùng một đơn vị công việc (transaction) và commit đồng bộ.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Lưu tất cả các thay đổi đã thực hiện trên DbContext xuống database.
        /// Thao tác này là bất đồng bộ và trả về số bản ghi bị ảnh hưởng.
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
