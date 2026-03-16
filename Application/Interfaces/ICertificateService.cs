using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICertificateService
    {
        Task CreateAsync(CreateCertificateDto dto);
        Task<IEnumerable<CertificateDto>> GetAllAsync();
        Task<CertificateDto?> GetByIdAsync(Guid id);
        Task<bool> DeleteAsync(Guid id);
        Task<CertificateDto?> UpdateAsync(Guid id, UpdateCertificateDto dto);
    }
}
