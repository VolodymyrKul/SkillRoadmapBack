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
    public class EmployerService : BaseService, IEmployerService
    {
        public EmployerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(EmployerDTO entity)
        {
            var value = new Employer();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployerRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.EmployerRepo.GetByIdAsync(id);
            await _unitOfWork.EmployerRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<EmployerDTO>> GetAll()
        {
            var employers = await _unitOfWork.EmployerRepo.GetAllAsync();
            List<EmployerDTO> employerDTOs = employers.Select(employer => _mapper.Map(employer, new EmployerDTO())).ToList();
            return employerDTOs;
        }

        public virtual async Task<EmployerDTO> GetIdAsync(int id)
        {
            var employer = await _unitOfWork.EmployerRepo.GetByIdAsync(id);
            if (employer == null)
                throw new Exception("Such employer not found");
            var dto = new EmployerDTO();
            _mapper.Map(employer, dto);
            return dto;
        }

        public virtual async Task<EmployerDTO> UpdateAsync(EmployerDTO entity)
        {
            var value = new Employer();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployerRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
