using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Interfaces
{
    public interface ICommunicationProgramService
    {
        Task CreateAsync(CommunicationProgramDto dto);
        Task<UpdateCommunicationProgramDto?> UpdateAsync(UpdateCommunicationProgramDto dto);
        Task<bool> DeleteAsync(Guid ProgramID);
        Task<IEnumerable<CommunicationProgramDto>> GetAllAsync();
        Task<CommunicationProgramDto?> GetByIdAsync(Guid programId);
    }
}
