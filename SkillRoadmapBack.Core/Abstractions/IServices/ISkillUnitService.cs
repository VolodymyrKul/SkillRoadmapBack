using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ISkillUnitService : IBaseService<SkillUnitDTO, SetSkillUnitDTO>
    {
        Task<List<SkillUnitDTO>> GetUserSkillIdAsync(int id);
        Task CreateAsync(SkillUnitDTO entity);
    }
}
