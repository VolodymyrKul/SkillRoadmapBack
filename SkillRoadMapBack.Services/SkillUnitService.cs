using AutoMapper;
using SkillRoadmapBack.Core.Abstractions;
using SkillRoadmapBack.Core.Abstractions.IServices;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
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
    public class SkillUnitService : BaseService, ISkillUnitService
    {
        public SkillUnitService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SetSkillUnitDTO entity)
        {
            var value = new SkillUnit();
            _mapper.Map(entity, value);
            value.IdUserSkill = (await _unitOfWork.UserSkillRepo.GetAllAsync()).FirstOrDefault(us => us.Skillname == entity.UserSkillName)?.Id;
            await _unitOfWork.SkillUnitRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }
        public virtual async Task CreateAsync(SkillUnitDTO entity)
        {
            var value = new SkillUnit();
            _mapper.Map(entity, value);
            //value.IdUserSkill = (await _unitOfWork.UserSkillRepo.GetAllAsync()).FirstOrDefault(us => us.Skillname == entity.UserSkillName)?.Id;
            await _unitOfWork.SkillUnitRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.SkillUnitRepo.GetByIdAsync(id);
            await _unitOfWork.SkillUnitRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<SkillUnitDTO>> GetAll()
        {
            var skillUnits = await _unitOfWork.SkillUnitRepo.GetAllAsync();
            List<SkillUnitDTO> skillUnitDTOs = skillUnits.Select(skillUnit => _mapper.Map(skillUnit, new SkillUnitDTO())).ToList();
            return skillUnitDTOs;
        }

        public virtual async Task<SkillUnitDTO> GetIdAsync(int id)
        {
            var skillUnit = await _unitOfWork.SkillUnitRepo.GetByIdAsync(id);
            if (skillUnit == null)
                throw new Exception("Such skillUnit not found");
            var dto = new SkillUnitDTO();
            _mapper.Map(skillUnit, dto);
            return dto;
        }

        public virtual async Task<SkillUnitDTO> UpdateAsync(SkillUnitDTO entity)
        {
            var value = new SkillUnit();
            _mapper.Map(entity, value);
            await _unitOfWork.SkillUnitRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<SkillUnitDTO>> GetUserSkillIdAsync(int id) 
        {
            var skillUnits = (await _unitOfWork.SkillUnitRepo.GetAllAsync()).Where(su => su.IdUserSkill == id);
            List<SkillUnitDTO> skillUnitDTOs = skillUnits.Select(skillUnit => _mapper.Map(skillUnit, new SkillUnitDTO())).ToList();
            return skillUnitDTOs;
        }
    }
}
