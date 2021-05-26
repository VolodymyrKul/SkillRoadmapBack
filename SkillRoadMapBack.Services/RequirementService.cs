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
    public class RequirementService : BaseService, IRequirementService
    {
        public RequirementService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(RequirementDTO entity)
        {
            var value = new Requirement();
            _mapper.Map(entity, value);
            await _unitOfWork.RequirementRepo.AddAsync(value);

            var genUserSkills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).ToList();
            var genSkillUnits = (await _unitOfWork.SkillUnitRepo.GetAllAsync()).ToList();
            List<(string, int, int)> fullUnits = new List<(string, int, int)>();
            string curSkill = "";
            foreach (var item in genSkillUnits)
            {
                curSkill = genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).Skillname + ". " + item.Unitname;
                var curUnit = (curSkill, (int)genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).IdEmployee, genUserSkills.FirstOrDefault(us => us.Id == item.IdUserSkill).SkillLevel);
                fullUnits.Add(curUnit);
                curSkill = "";
            }
            List<Comparation> comparations = new List<Comparation>();
            var curUnits = fullUnits.Where(unit => unit.Item1 == value.ReqTitle);
            foreach (var item in curUnits)
            {
                comparations.Add(new Comparation
                {
                    Id = 0,
                    IdEmployee = item.Item2,
                    IdRequirement = value.Id,
                    IsMeetCriteria = item.Item3 >= value.ReqLevel ? true : false
                });
            }
            foreach(var com in comparations)
            {
                await _unitOfWork.ComparationRepo.AddAsync(com);
            }
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.RequirementRepo.GetByIdAsync(id);
            var comps = (await _unitOfWork.ComparationRepo.GetAllAsync()).Where(com => com.IdRequirement == id);
            await _unitOfWork.ComparationRepo.DeleteRangeAsync(comps);
            await _unitOfWork.RequirementRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<RequirementDTO>> GetAll()
        {
            var requirements = await _unitOfWork.RequirementRepo.GetAllAsync();
            List<RequirementDTO> requirementDTOs = requirements.Select(requirement => _mapper.Map(requirement, new RequirementDTO())).ToList();
            return requirementDTOs;
        }

        public virtual async Task<RequirementDTO> GetIdAsync(int id)
        {
            var requirement = await _unitOfWork.RequirementRepo.GetByIdAsync(id);
            if (requirement == null)
                throw new Exception("Such category not found");
            var dto = new RequirementDTO();
            _mapper.Map(requirement, dto);
            return dto;
        }

        public virtual async Task<RequirementDTO> UpdateAsync(RequirementDTO entity)
        {
            var value = new Requirement();
            _mapper.Map(entity, value);
            await _unitOfWork.RequirementRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<List<RequirementDTO>> GetSkillTemplateIdAsync(int id)
        {
            var requirements = (await _unitOfWork.RequirementRepo.GetAllAsync()).Where(r => r.IdSkillTemplate == id);
            List<RequirementDTO> requirementDTOs = requirements.Select(requirement => _mapper.Map(requirement, new RequirementDTO())).ToList();
            return requirementDTOs;
        }
    }
}
