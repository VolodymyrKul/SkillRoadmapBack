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
    public class ComparationService : BaseService, IComparationService
    {
        public ComparationService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(ComparationDTO entity)
        {
            var value = new Comparation();
            _mapper.Map(entity, value);
            await _unitOfWork.ComparationRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.ComparationRepo.GetByIdAsync(id);
            await _unitOfWork.ComparationRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<ComparationDTO>> GetAll()
        {
            var comparations = await _unitOfWork.ComparationRepo.GetAllAsync();
            List<ComparationDTO> comparationDTOs = comparations.Select(comparation => _mapper.Map(comparation, new ComparationDTO())).ToList();
            return comparationDTOs;
        }

        public virtual async Task<ComparationDTO> GetIdAsync(int id)
        {
            var comparation = await _unitOfWork.ComparationRepo.GetByIdAsync(id);
            if (comparation == null)
                throw new Exception("Such category not found");
            var dto = new ComparationDTO();
            _mapper.Map(comparation, dto);
            return dto;
        }

        public virtual async Task<ComparationDTO> UpdateAsync(ComparationDTO entity)
        {
            var value = new Comparation();
            _mapper.Map(entity, value);
            await _unitOfWork.ComparationRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<ComparationDTO>> GetRequirementIdAsync(int id)
        {
            var comparations = (await _unitOfWork.ComparationRepo.GetAllAsync()).Where(c => c.IdRequirement == id);
            List<ComparationDTO> comparationDTOs = comparations.Select(comparation => _mapper.Map(comparation, new ComparationDTO())).ToList();
            return comparationDTOs;
        }

        public virtual async Task<List<ComparationDTO>> GetEmployeeIdAsync(int id)
        {
            var comparations = (await _unitOfWork.ComparationRepo.GetAllAsync()).Where(c => c.IdEmployee == id);
            List<ComparationDTO> comparationDTOs = comparations.Select(comparation => _mapper.Map(comparation, new ComparationDTO())).ToList();
            return comparationDTOs;
        }
    }
}
