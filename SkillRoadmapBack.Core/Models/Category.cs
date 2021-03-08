using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Category : IBaseEntity
    {
        public Category()
        {
            UserSkills = new HashSet<UserSkill>();
            Trainings = new HashSet<Training>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
