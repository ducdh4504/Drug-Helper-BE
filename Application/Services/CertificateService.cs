using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Interfaces;
using Org.BouncyCastle.Ocsp;

namespace Application.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CertificateService(ICertificateRepository certificateRepository, IUnitOfWork unitOfWork)
        {
            _certificateRepository = certificateRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAsync(CreateCertificateDto dto)
        {
            var certificate = new Certificate
            {
                CertificateID = Guid.NewGuid(),
                UserID = dto.UserID,
                ImgUrl = dto.ImgUrl,
                CertificateName = dto.CertificateName,
                DateAcquired = dto.DateAcquired,
                Status = dto.Status
            };

            await _certificateRepository.AddAsync(certificate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if(certificate == null)
            {
                return false;
            }
            _certificateRepository.Remove(certificate);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CertificateDto>> GetAllAsync()
        {
            var listCertificate = await _certificateRepository.GetAllAsync();
            return listCertificate.Select(e => new CertificateDto
            {
                CertificateID = e.CertificateID,
                UserID = e.UserID,
                ImgUrl = e.ImgUrl,
                CertificateName = e.CertificateName,
                DateAcquired = e.DateAcquired,
                Status = e.Status
            }).ToList();
        }

        public async Task<CertificateDto?> GetByIdAsync(Guid id)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);
            if(certificate == null)
            {
                return null;
            }
            var certificateDto = new CertificateDto
            {
                CertificateID = certificate.CertificateID,
                UserID = certificate.UserID,
                ImgUrl = certificate.ImgUrl,
                CertificateName = certificate.CertificateName,
                DateAcquired = certificate.DateAcquired,
                Status = certificate.Status
            };
            return certificateDto;
        }

        public async Task<CertificateDto?> UpdateAsync(Guid id, UpdateCertificateDto dto)
        {
            var certificate = await _certificateRepository.GetByIdAsync(id);

            if(certificate == null)
            {
                return null;
            }

            certificate.ImgUrl = dto.ImgUrl;
            certificate.CertificateName = dto.CertificateName;
            certificate.DateAcquired = dto.DateAcquired;
            certificate.Status = dto.Status;

            await _unitOfWork.SaveChangesAsync();
            return new CertificateDto
            {
                CertificateID = certificate.CertificateID,
                UserID = certificate.UserID,
                ImgUrl = certificate.ImgUrl,
                CertificateName = certificate.CertificateName,
                DateAcquired = certificate.DateAcquired,
                Status = certificate.Status
            };
        }
    }
}
