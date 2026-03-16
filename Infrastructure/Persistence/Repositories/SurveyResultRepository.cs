using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SurveyResultRepository : GenericRepository<SurveyResult>,ISurveyResultRepository
    {
        public SurveyResultRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<SurveyResult?> GetBySurveyAndProgramAsync(Guid surveyId, Guid programId)
        {
            return await _dbSet.FirstOrDefaultAsync(p => p.SurveyID == surveyId && p.ProgramID == programId);
        }

        public async Task<IEnumerable<SurveyResult>> GetBySurveyIdAsync(Guid surveyId)
        {
            return await _dbSet.Where(p => p.SurveyID == surveyId).ToListAsync();
        }
    }
}
