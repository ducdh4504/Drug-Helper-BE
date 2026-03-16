using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Persistence.Interfaces
{
    public interface IAssessmentResultRepository : IGenericRepository<AssessmentResult>
    {
        Task<AssessmentResult?> GetByAssessmentAndUserAsync(Guid assessmentId, Guid userId);
    }
}
