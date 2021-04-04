using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class SetTrainingDTO
    {
        public string TrainingTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainingLevel { get; set; }
        public double Payment { get; set; }
        public string CoachEmail { get; set; }
        public string CategoryName { get; set; }
    }
}
