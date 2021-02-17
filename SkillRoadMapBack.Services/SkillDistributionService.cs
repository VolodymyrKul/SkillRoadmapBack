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
    public class SkillDistributionService : BaseService, ISkillDistributionService
    {
        public SkillDistributionService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SkillDistributionDTO entity)
        {
            var value = new SkillDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillDistributionRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SkillDistributionRepo.GetByIdAsync(id);
            await _unitOfWork.SkillDistributionRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<SkillDistributionDTO>> GetAll()
        {
            var skillDistributions = await _unitOfWork.SkillDistributionRepo.GetAllAsync();
            List<SkillDistributionDTO> skillDistributionDTOs = skillDistributions.Select(skillDistribution => _mapper.Map(skillDistribution, new SkillDistributionDTO())).ToList();
            return skillDistributionDTOs;
        }

        public virtual async Task<SkillDistributionDTO> GetIdAsync(int id)
        {
            var skillDistribution = await _unitOfWork.SkillDistributionRepo.GetByIdAsync(id);
            if (skillDistribution == null)
                throw new Exception("Such skillDistribution not found");
            var dto = new SkillDistributionDTO();
            _mapper.Map(skillDistribution, dto);
            return dto;
        }

        public virtual async Task<SkillDistributionDTO> UpdateAsync(SkillDistributionDTO entity)
        {
            var value = new SkillDistribution();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillDistributionRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
