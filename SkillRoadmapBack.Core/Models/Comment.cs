using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Comment : IBaseEntity
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public int IdEmployer { get; set; }
        public int IdUserSkill { get; set; }
    }
}
