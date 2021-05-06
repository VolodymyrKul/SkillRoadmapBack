using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class SkillTemplate : IBaseEntity
    {
        public int Id { get; set; }
        public string TemplateTitle { get; set; }
        public string Description { get; set; }
        public int AverageSalary { get; set; }
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
