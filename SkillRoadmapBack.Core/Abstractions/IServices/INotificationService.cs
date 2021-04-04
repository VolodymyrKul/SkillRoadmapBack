using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface INotificationService : IBaseService<NotificationDTO, NotificationDTO>
    {
        Task<List<GetNotificationDTO>> GetByEmployee(string email);
        Task<List<GetNotificationDTO>> GetByEmployer(string email);
    }
}
