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
        public string EmployerEmail { get; set; }
        public string EmployerNSN { get; set; }
        public string SkillName { get; set; }
    }
}
