using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class SkillMetricDTO
    {
        public int Id { get; set; }
        public string MetricName { get; set; }
        public int MetricValue { get; set; }
        public double MetricInfluence { get; set; }
        public int? IdUserSkill { get; set; }
        public string SkillName { get; set; }
    }
}
