using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class SetSkillMetricDTO
    {
        public string MetricName { get; set; }
        public int MetricValue { get; set; }
        public double MetricInfluence { get; set; }
        public string Skillname { get; set; }
    }
}
