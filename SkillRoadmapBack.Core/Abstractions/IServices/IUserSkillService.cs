using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IUserSkillService : IBaseService<UserSkillDTO, UserSkillDTO>
    {
        Task<List<UserSkillDTO>> GetByYear(int user, int year);
    }
}
