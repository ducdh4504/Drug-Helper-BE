using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Infrastructure.Persistence.Repositories
{
    public class AssessmentResultRepository : GenericRepository<AssessmentResult>, IAssessmentResultRepository
    {
        public AssessmentResultRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<AssessmentResult?> GetByAssessmentAndUserAsync(Guid assessmentId, Guid userId)
        {
            return  _dbSet.FirstOrDefault(r => r.AssessmentID == assessmentId && r.UserID == userId);
        }
    }
}
