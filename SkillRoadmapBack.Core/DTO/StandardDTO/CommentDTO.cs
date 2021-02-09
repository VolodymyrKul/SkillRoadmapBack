using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int IdEmployer { get; set; }
        public int IdUserSkill { get; set; }
    }
}
