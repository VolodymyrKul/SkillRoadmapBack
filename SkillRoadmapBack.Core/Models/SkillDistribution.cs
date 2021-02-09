using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class SkillDistribution : IBaseEntity
    {
        public int Id { get; set; }
        public int IdParentSkill { get; set; }
        public int IdChildSkill { get; set; }
        
        public UserSkill IdParentSkillNavigation { get; set; }
        public UserSkill IdChildSkillNavigation { get; set; }
    }
}
