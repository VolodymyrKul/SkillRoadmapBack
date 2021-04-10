using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class TrainingDTO
    {
        public int Id { get; set; }
        public string TrainingTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainingLevel { get; set; }
        public double Payment { get; set; }
        public int? IdCoach { get; set; }
        public int? IdCategory { get; set; }
        public string CoachEmail { get; set; }
        public string CoachNSN { get; set; }
        public string CategoryTitle { get; set; }
    }
}
