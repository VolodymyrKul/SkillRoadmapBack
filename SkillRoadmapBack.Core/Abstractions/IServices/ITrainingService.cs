using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ITrainingService : IBaseService<TrainingDTO, TrainingDTO>
    {
        Task<List<SetTrainingDTO>> GetByCoach(string coach);
        Task<List<TrainingDTO>> GetByCoach(int coachId);
        Task<List<SetTrainingDTO>> GetByCategory(string category);
        Task<List<TrainingDTO>> GetByCategory(int categoryId);
        Task<List<SetTrainingDTO>> GetAllWithCategs();
    }
}
