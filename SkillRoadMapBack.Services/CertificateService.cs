using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using SkillRoadmapBack.Core.Models;
using SkillRoadMapBack.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadMapBack.Services
{
    public class CertificateService : BaseService, ICertificateService
    {
        public CertificateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CertificateDTO entity)
        {
            var value = new Certificate();
            _mapper.Map(entity, value);
            await _unitOfWork.CertificateRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CertificateRepo.GetByIdAsync(id);
            await _unitOfWork.CertificateRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CertificateDTO>> GetAll()
        {
            var certificates = await _unitOfWork.CertificateRepo.GetAllAsync();
            List<CertificateDTO> certificateDTOs = certificates.Select(certificate => _mapper.Map(certificate, new CertificateDTO())).ToList();
            return certificateDTOs;
        }

        public virtual async Task<CertificateDTO> GetIdAsync(int id)
        {
            var certificate = await _unitOfWork.CertificateRepo.GetByIdAsync(id);
            if (certificate == null)
                throw new Exception("Such category not found");
            var dto = new CertificateDTO();
            _mapper.Map(certificate, dto);
            return dto;
        }

        public virtual async Task<CertificateDTO> UpdateAsync(CertificateDTO entity)
        {
            var value = new Certificate();
            _mapper.Map(entity, value);
            await _unitOfWork.CertificateRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
