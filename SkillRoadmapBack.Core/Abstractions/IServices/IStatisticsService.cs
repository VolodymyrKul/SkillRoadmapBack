using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface IStatisticsService : IBaseService<StatisticsDTO, StatisticsDTO>
    {
        Task<StatisticsDTO> UpdateStats(string email, int year);
    }
}
