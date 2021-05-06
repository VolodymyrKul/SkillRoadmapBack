using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IComparationService : IBaseService<ComparationDTO, ComparationDTO>
    {
        Task<List<ComparationDTO>> GetRequirementIdAsync(int id);
        Task<List<ComparationDTO>> GetEmployeeIdAsync(int id);
    }
}
