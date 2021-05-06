using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Requirement : IBaseEntity
    {
        public int Id { get; set; }
        public string ReqTitle { get; set; }
        public int ReqLevel { get; set; }
        public int? IdSkillTemplate { get; set; }
        public SkillTemplate IdSkillTemplateNavigation { get; set; }
        public virtual ICollection<Comparation> Comparations { get; set; }
    }
}
