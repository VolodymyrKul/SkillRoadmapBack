using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class GetCommentDTO
    {
        public string CommentText { get; set; }
        public string EmployerEmail { get; set; }
        public string UserSkillName { get; set; }
    }
}
