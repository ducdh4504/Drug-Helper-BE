using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure.Persistence.Interfaces
{
    public  interface IAssessmentRepository: IGenericRepository<Assessment>
    {
        Task<Assessment?> GetActiveAssessmentByIdAsync(Guid assessmentID);
        Task<IEnumerable<Assessment>> GetAllActiveAssessmentAsync();
    }
}
