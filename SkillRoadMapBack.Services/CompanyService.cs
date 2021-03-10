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
    public class CompanyService : BaseService, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(CompanyDTO entity)
        {
            var value = new Company();
            _mapper.Map(entity, value);
            await _unitOfWork.CompanyRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.CompanyRepo.GetByIdAsync(id);
            await _unitOfWork.CompanyRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<CompanyDTO>> GetAll()
        {
            var companies = await _unitOfWork.CompanyRepo.GetAllAsync();
            List<CompanyDTO> companyDTOs = companies.Select(company => _mapper.Map(company, new CompanyDTO())).ToList();
            return companyDTOs;
        }

        public virtual async Task<CompanyDTO> GetIdAsync(int id)
        {
            var company = await _unitOfWork.CompanyRepo.GetByIdAsync(id);
            if (company == null)
                throw new Exception("Such category not found");
            var dto = new CompanyDTO();
            _mapper.Map(company, dto);
            return dto;
        }

        public virtual async Task<CompanyDTO> UpdateAsync(CompanyDTO entity)
        {
            var value = new Company();
            _mapper.Map(entity, value);
            await _unitOfWork.CompanyRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
