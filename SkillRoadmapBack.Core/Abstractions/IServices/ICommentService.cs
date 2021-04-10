using SkillRoadmapBack.Core.Abstractions.IServices.Base;
using SkillRoadmapBack.Core.DTO.SpecializedDTO;
using SkillRoadmapBack.Core.DTO.StandardDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SkillRoadmapBack.Core.Abstractions.IServices
{
    public interface ICommentService : IBaseService<CommentDTO, CommentDTO>
    {
        Task<List<GetCommentDTO>> GetBySkill(string user);
        Task<List<CommentDTO>> GetByEmployee(int userId);
    }
}
