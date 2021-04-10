using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IUserSkillService : IBaseService<UserSkillDTO, SetUserSkillDTO>
    {
        Task<List<GetUserSkillDTO>> GetByYear(string user, int year);
        Task<List<UserSkillDTO>> GetByYear(int userId, int year);
        Task<List<int>> GetYears(string user);
        Task<List<int>> GetYears(int userId);
        Task<List<GetUserSkillDTO>> GetOnlyUSkills(string user);
        Task<List<UserSkillDTO>> GetOnlyUSkills(int userId);
    }
}
