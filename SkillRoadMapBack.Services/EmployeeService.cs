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
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(EmployeeDTO entity)
        {
            var value = new Employee();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployeeRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.EmployeeRepo.GetByIdAsync(id);
            await _unitOfWork.EmployeeRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<EmployeeDTO>> GetAll()
        {
            var employees = await _unitOfWork.EmployeeRepo.GetAllAsync();
            List<EmployeeDTO> employeeDTOs = employees.Select(employee => _mapper.Map(employee, new EmployeeDTO())).ToList();
            return employeeDTOs;
        }

        public virtual async Task<EmployeeDTO> GetIdAsync(int id)
        {
            var employee = await _unitOfWork.EmployeeRepo.GetByIdAsync(id);
            if (employee == null)
                throw new Exception("Such employee not found");
            var dto = new EmployeeDTO();
            _mapper.Map(employee, dto);
            return dto;
        }

        public virtual async Task<EmployeeDTO> UpdateAsync(EmployeeDTO entity)
        {
            var value = new Employee();
            _mapper.Map(entity, value);
            await _unitOfWork.EmployeeRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
