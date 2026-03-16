using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface ISurveyResultRepository:IGenericRepository<SurveyResult>
    {
        Task<SurveyResult?> GetBySurveyAndProgramAsync(Guid surveyId, Guid programId);
        Task<IEnumerable<SurveyResult>> GetBySurveyIdAsync(Guid surveyId);
    }
}
