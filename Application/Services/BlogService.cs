using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IUnitOfWork _unitOfWork;
        

        public BlogService(IBlogRepository blogRepository, IUnitOfWork unitOfWork)
        {
            _blogRepository = blogRepository;
            _unitOfWork = unitOfWork;
           
        }

        public async Task<BlogDto?> CreateBlogAsync(CreateBlogDto dto)
        {
            
            var blog = new Blog
            {
                BlogID = Guid.NewGuid(),
                Title = dto.Title,
                UserID= dto.UserID,
                ImgUrl = dto.ImgUrl,
                Content = dto.Content,
                PublishDate = dto.PublishDate,
                Status = dto.Status,
                ResultLevel = dto.ResultLevel
            };

            await _blogRepository.AddAsync(blog);
            await _unitOfWork.SaveChangesAsync();

            return new BlogDto
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                ImgUrl = blog.ImgUrl,
                Content = blog.Content,
                PublishDate = blog.PublishDate,
                Status = blog.Status,
                ResultLevel = blog.ResultLevel,
                UserID = blog.UserID
            };
        }
        public async Task<IEnumerable<BlogDto>> GetAllBlogsAsync()
        {
            var blogs = await _blogRepository.GetAllAsync();
            return blogs.Select(b => new BlogDto
            {
                BlogID = b.BlogID,
                Title = b.Title,
                ImgUrl = b.ImgUrl,
                Content = b.Content,
                PublishDate = b.PublishDate,
                Status = b.Status,
                ResultLevel = b.ResultLevel,
                UserID = b.UserID
            });
        }
        public async Task<BlogDto?> GetBlogByIdAsync(Guid blogId)
        {
            var blog = await _blogRepository.GetByIdAsync(blogId);
            if (blog == null) return null;

            return new BlogDto
            {
                BlogID = blog.BlogID,
                Title = blog.Title,
                ImgUrl = blog.ImgUrl,
                Content = blog.Content,
                PublishDate = blog.PublishDate,
                Status = blog.Status,
                ResultLevel = blog.ResultLevel,
                UserID = blog.UserID
            };
        }
        public async Task<bool> UpdateBlogAsync(UpdateBlogDto dto)
        {
            var blog = await _blogRepository.GetByIdAsync(dto.BlogID);
            if (blog == null) return false;

            blog.Title = dto.Title;
            blog.ImgUrl = dto.ImgUrl;
            blog.Content = dto.Content;
            blog.PublishDate = dto.PublishDate;
            blog.Status = dto.Status;
            blog.ResultLevel = dto.ResultLevel;

            _blogRepository.Update(blog);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBlogAsync(Guid blogId)
        {
            var blog = await _blogRepository.GetByIdAsync(blogId);
            if (blog == null) return false;

             _blogRepository.Remove(blog);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<BlogDto>> SearchBlogsByTitleAsync(string keyword)
        {
            var blogs = await _blogRepository.FindAsync(b =>
                !string.IsNullOrEmpty(b.Title) &&
                b.Title.Contains(keyword));

            return blogs.Select(b => new BlogDto
            {
                BlogID = b.BlogID,
                Title = b.Title,
                ImgUrl = b.ImgUrl,
                Content = b.Content,
                PublishDate = b.PublishDate,
                Status = b.Status,
                ResultLevel = b.ResultLevel
            }).ToList();
        }
    }
}
