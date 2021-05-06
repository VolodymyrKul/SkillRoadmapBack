using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Comparation : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdRequirement { get; set; }
        public Requirement IdRequirementNavigation { get; set; }
        public int? IdEmployee { get; set; }
        public Employee IdEmployeeNavigation { get; set; }
        public bool IsMeetCriteria { get; set; }
    }
}
