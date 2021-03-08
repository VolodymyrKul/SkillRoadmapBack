using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class StatisticsDTO
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public int StatYear { get; set; }
        public int NewSkillCount { get; set; }
        public long StudyingTime { get; set; }
        public double AverageSkillLevel { get; set; }
        public double BetterThanPercent { get; set; }
    }
}
