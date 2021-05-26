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
    public class UserSkillService : BaseService, IUserSkillService
    {
        public UserSkillService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }

        public virtual async Task CreateAsync(SetUserSkillDTO entity)
        {
            var value = new UserSkill();
            _mapper.Map(entity, value);
            value.IdCategory = (await _unitOfWork.CategoryRepo.GetAllAsync()).FirstOrDefault(cat => cat.Title == entity.CategoryName)?.Id;
            value.IdEmployee = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(emp => emp.Email == entity.EmployeeEmail)?.Id;
            await _unitOfWork.UserSkillRepo.AddAsync(value);
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task CreateAsync(UserSkillDTO entity)
        {
            var value = new UserSkill();
            _mapper.Map(entity, value);
            await _unitOfWork.UserSkillRepo.AddAsync(value);
            var notif = new Notification();
            await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.UserSkillRepo.GetByIdAsync(id);
            var skUnits = (await _unitOfWork.SkillUnitRepo.GetAllAsync()).Where(su => su.IdUserSkill == id);
            var skMetric = (await _unitOfWork.SkillMetricRepo.GetAllAsync()).Where(sm => sm.IdUserSkill == id);
            var comments = (await _unitOfWork.CommentRepo.GetAllAsync()).Where(cm => cm.IdUserSkill == id);

            await _unitOfWork.SkillUnitRepo.DeleteRangeAsync(skUnits);
            await _unitOfWork.SkillMetricRepo.DeleteRangeAsync(skMetric);
            await _unitOfWork.CommentRepo.DeleteRangeAsync(comments);
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

        public virtual async Task<List<GetUserSkillDTO>> GetByYear(string user, int year)
        {
            List<GetUserSkillDTO> userSkillDTOs = null;
            var userSkills = await _unitOfWork.UserSkillRepo.GetAllAsync();
            var yearSkills = userSkills.ToList().Where(us => us.IdEmployeeNavigation.Email == user && (us.StartDate.Year == year || us.EndDate.Year == year));
            if(yearSkills.Count() == 0)
            {
                return new List<GetUserSkillDTO>();
            }
            else
            {
                List<SkillUnit> skillUnits = (await _unitOfWork.SkillUnitRepo.GetAllAsync()).ToList();
                List<UserSkill> skillWithUnits = new List<UserSkill>();
                List<SkillUnit> childUnits = null;
                List<int> unitsIndex = new List<int>();
                foreach (UserSkill userSkill in yearSkills)
                {
                    skillWithUnits.Add(userSkill);
                    unitsIndex.Add(skillWithUnits.Count - 1);
                    childUnits = skillUnits.Where(su => su.IdUserSkill == userSkill.Id).ToList();
                    foreach(SkillUnit skillUnit in childUnits)
                    {
                        skillWithUnits.Add(new UserSkill()
                        {
                            Id = skillUnit.Id,
                            Skillname = skillUnit.Unitname,
                            StartDate = skillUnit.StartDate,
                            EndDate = skillUnit.EndDate,
                            IdCategory = userSkill.IdCategory,
                            IdCategoryNavigation = userSkill.IdCategoryNavigation,
                            SkillLevel = skillUnit.UnitLevel,
                            IdEmployee = userSkill.IdEmployee,
                            IdEmployeeNavigation = userSkill.IdEmployeeNavigation
                        });
                    }
                }
                userSkillDTOs = skillWithUnits.Select(userSkill => _mapper.Map(userSkill, new GetUserSkillDTO())).ToList();
                foreach(var unitIndex in unitsIndex)
                {
                    userSkillDTOs[unitIndex].IsUserSkill = true;
                }
                return userSkillDTOs;
            }

            //List<UserSkillDTO> userSkillDTOs = userSkills.Select(userSkill => _mapper.Map(userSkill, new UserSkillDTO())).ToList();
            //return userSkillDTOs;
        }

        public virtual async Task<List<UserSkillDTO>> GetByYear(int userId, int year)
        {
            List<UserSkillDTO> userSkillDTOs = null;
            var userSkills = await _unitOfWork.UserSkillRepo.GetAllAsync();
            var yearSkills = userSkills.ToList().Where(us => us.IdEmployeeNavigation.Id == userId && (us.StartDate.Year == year || us.EndDate.Year == year));
            if (yearSkills.Count() == 0)
            {
                return new List<UserSkillDTO>();
            }
            else
            {
                List<SkillUnit> skillUnits = (await _unitOfWork.SkillUnitRepo.GetAllAsync()).ToList();
                List<UserSkill> skillWithUnits = new List<UserSkill>();
                List<SkillUnit> childUnits = null;
                List<int> unitsIndex = new List<int>();
                foreach (UserSkill userSkill in yearSkills)
                {
                    skillWithUnits.Add(userSkill);
                    unitsIndex.Add(skillWithUnits.Count - 1);
                    childUnits = skillUnits.Where(su => su.IdUserSkill == userSkill.Id).ToList();
                    foreach (SkillUnit skillUnit in childUnits)
                    {
                        skillWithUnits.Add(new UserSkill()
                        {
                            Id = skillUnit.Id,
                            Skillname = skillUnit.Unitname,
                            StartDate = skillUnit.StartDate,
                            EndDate = skillUnit.EndDate,
                            IdCategory = userSkill.IdCategory,
                            IdCategoryNavigation = userSkill.IdCategoryNavigation,
                            SkillLevel = skillUnit.UnitLevel,
                            IdEmployee = userSkill.IdEmployee,
                            IdEmployeeNavigation = userSkill.IdEmployeeNavigation
                        });
                    }
                }
                userSkillDTOs = skillWithUnits.Select(userSkill => _mapper.Map(userSkill, new UserSkillDTO())).ToList();
                foreach (var unitIndex in unitsIndex)
                {
                    userSkillDTOs[unitIndex].IsUserSkill = true;
                }
                return userSkillDTOs;
            }

            //List<UserSkillDTO> userSkillDTOs = userSkills.Select(userSkill => _mapper.Map(userSkill, new UserSkillDTO())).ToList();
            //return userSkillDTOs;
        }

        public virtual async Task<List<int>> GetYears(string user) 
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Email == user);
            if(emp != null)
            {
                var skillYears = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdEmployee == emp.Id).Select(us => us.StartDate.Year).Distinct();
                return skillYears.ToList();
            }
            else
            {
                return new List<int>();
            }
        }

        public virtual async Task<List<int>> GetYears(int userId)
        {
            var emp = (await _unitOfWork.EmployeeRepo.GetAllAsync()).FirstOrDefault(e => e.Id == userId);
            if (emp != null)
            {
                var skillYears = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdEmployee == emp.Id).Select(us => us.StartDate.Year).Distinct();
                return skillYears.ToList();
            }
            else
            {
                return new List<int>();
            }
        }

        public virtual async Task<List<GetUserSkillDTO>> GetOnlyUSkills(string user)
        {
            List<GetUserSkillDTO> getUserSkillDTOs = new List<GetUserSkillDTO>();
            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdEmployeeNavigation.Email == user);
            if (skills.Count() > 0)
            {
                getUserSkillDTOs = skills.Select(skill => _mapper.Map(skill, new GetUserSkillDTO())).ToList();
                foreach (var skill in getUserSkillDTOs)
                {
                    skill.IsUserSkill = true;
                }
            }
            return getUserSkillDTOs;
        }

        public virtual async Task<List<UserSkillDTO>> GetOnlyUSkills(int userId)
        {
            List<UserSkillDTO> getUserSkillDTOs = new List<UserSkillDTO>();
            var skills = (await _unitOfWork.UserSkillRepo.GetAllAsync()).Where(us => us.IdEmployeeNavigation.Id == userId);
            if (skills.Count() > 0)
            {
                getUserSkillDTOs = skills.Select(skill => _mapper.Map(skill, new UserSkillDTO())).ToList();
                foreach (var skill in getUserSkillDTOs)
                {
                    skill.IsUserSkill = true;
                }
            }
            return getUserSkillDTOs;
        }
    }
}
