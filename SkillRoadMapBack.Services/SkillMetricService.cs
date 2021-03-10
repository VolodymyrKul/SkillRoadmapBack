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
    public class SkillMetricService : BaseService, ISkillMetricService
    {
        public SkillMetricService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SkillMetricDTO entity)
        {
            var value = new SkillMetric();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillMetricRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SkillMetricRepo.GetByIdAsync(id);
            await _unitOfWork.SkillMetricRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<SkillMetricDTO>> GetAll()
        {
            var skillMetrics = await _unitOfWork.SkillMetricRepo.GetAllAsync();
            List<SkillMetricDTO> skillMetricDTOs = skillMetrics.Select(skillMetric => _mapper.Map(skillMetric, new SkillMetricDTO())).ToList();
            return skillMetricDTOs;
        }

        public virtual async Task<SkillMetricDTO> GetIdAsync(int id)
        {
            var skillMetric = await _unitOfWork.SkillMetricRepo.GetByIdAsync(id);
            if (skillMetric == null)
                throw new Exception("Such category not found");
            var dto = new SkillMetricDTO();
            _mapper.Map(skillMetric, dto);
            return dto;
        }

        public virtual async Task<SkillMetricDTO> UpdateAsync(SkillMetricDTO entity)
        {
            var value = new SkillMetric();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillMetricRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
