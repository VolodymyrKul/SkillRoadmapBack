using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IRequirementService : IBaseService<RequirementDTO, RequirementDTO>
    {
        Task<List<RequirementDTO>> GetSkillTemplateIdAsync(int id);
    }
}
