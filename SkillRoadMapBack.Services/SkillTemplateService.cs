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
    public class SkillTemplateService : BaseService, ISkillTemplateService
    {
        public SkillTemplateService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SkillTemplateDTO entity)
        {
            var value = new SkillTemplate();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillTemplateRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SkillTemplateRepo.GetByIdAsync(id);
            var reqs = (await _unitOfWork.RequirementRepo.GetAllAsync()).Where(req => req.IdSkillTemplate == id);
            await _unitOfWork.RequirementRepo.DeleteRangeAsync(reqs);
            await _unitOfWork.SkillTemplateRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<SkillTemplateDTO>> GetAll()
        {
            var skillTemplates = await _unitOfWork.SkillTemplateRepo.GetAllAsync();
            List<SkillTemplateDTO> skillTemplateDTOs = skillTemplates.Select(skillTemplate => _mapper.Map(skillTemplate, new SkillTemplateDTO())).ToList();
            return skillTemplateDTOs;
        }

        public virtual async Task<SkillTemplateDTO> GetIdAsync(int id)
        {
            var skillTemplate = await _unitOfWork.SkillTemplateRepo.GetByIdAsync(id);
            if (skillTemplate == null)
                throw new Exception("Such category not found");
            var dto = new SkillTemplateDTO();
            _mapper.Map(skillTemplate, dto);
            return dto;
        }

        public virtual async Task<SkillTemplateDTO> UpdateAsync(SkillTemplateDTO entity)
        {
            var value = new SkillTemplate();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillTemplateRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
