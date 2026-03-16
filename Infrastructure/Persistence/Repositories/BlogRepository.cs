using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class BlogRepository : GenericRepository<Blog> , IBlogRepository
    {
        public BlogRepository(ApplicationDbContext context) : base(context) 
        { 
        }
    }
}
