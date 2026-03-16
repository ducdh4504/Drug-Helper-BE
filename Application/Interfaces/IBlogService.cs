using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface IBlogService
    {
        Task<BlogDto?> CreateBlogAsync(CreateBlogDto dto);
        Task<IEnumerable<BlogDto>> GetAllBlogsAsync();
        Task<BlogDto?> GetBlogByIdAsync(Guid blogId);
        Task<bool> UpdateBlogAsync(UpdateBlogDto dto);
        Task<bool> DeleteBlogAsync(Guid blogId);
        Task<IEnumerable<BlogDto>> SearchBlogsByTitleAsync(string keyword);

    }
}
