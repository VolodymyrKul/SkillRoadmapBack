using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ITrainingMemberService : IBaseService<TrainingMemberDTO, TrainingMemberDTO>
    {
        Task<List<TrainingMemberDTO>> GetTrainingIdAsync(int id);
        Task<List<TrainingMemberDTO>> GetMemberIdAsync(int id);
    }
}
