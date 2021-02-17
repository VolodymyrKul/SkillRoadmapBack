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
    public class UserSkillService : BaseService, IUserSkillService
    {
        public UserSkillService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(UserSkillDTO entity)
        {
            var value = new UserSkill();
            _mapper.Map(entity, value);
            await _unitOfWork.UserSkillRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UserSkillRepo.GetByIdAsync(id);
            await _unitOfWork.UserSkillRepo.DeleteAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<List<UserSkillDTO>> GetAll()
        {
            var userSkills = await _unitOfWork.UserSkillRepo.GetAllAsync();
            List<UserSkillDTO> userSkillDTOs = userSkills.Select(userSkill => _mapper.Map(userSkill, new UserSkillDTO())).ToList();
            return userSkillDTOs;
        }

        public virtual async Task<UserSkillDTO> GetIdAsync(int id)
        {
            var userSkill = await _unitOfWork.UserSkillRepo.GetByIdAsync(id);
            if (userSkill == null)
                throw new Exception("Such userSkill not found");
            var dto = new UserSkillDTO();
            _mapper.Map(userSkill, dto);
            return dto;
        }

        public virtual async Task<UserSkillDTO> UpdateAsync(UserSkillDTO entity)
        {
            var value = new UserSkill();
            _mapper.Map(entity, value);
            await _unitOfWork.UserSkillRepo.UpdateAsync(value);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
    }
}
