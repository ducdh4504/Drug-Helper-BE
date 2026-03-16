using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
    {
        public class AssessmentRepository : GenericRepository<Assessment>, IAssessmentRepository
        {
            public AssessmentRepository(ApplicationDbContext context) : base(context)
            {
            }
            public async Task<Assessment?> GetActiveAssessmentByIdAsync(Guid assessmentID)
            {
                return await _dbSet.FirstOrDefaultAsync(x => x.AssessmentID == assessmentID && x.Status == ActivityStatusEnum.Active);
            }
            public async Task<IEnumerable<Assessment>> GetAllActiveAssessmentAsync()
            {
                return await _dbSet.Where(x => x.Status == ActivityStatusEnum.Active).ToListAsync();
            }

        }
    }