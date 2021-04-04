using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class SkillMetric : IBaseEntity
    {
        public int Id { get; set; }
        public string MetricName { get; set; }
        public int MetricValue { get; set; }
        public double MetricInfluence { get; set; }
        public int? IdUserSkill { get; set; }
        public UserSkill IdUserSkillNavigation { get; set; }
    }
}
