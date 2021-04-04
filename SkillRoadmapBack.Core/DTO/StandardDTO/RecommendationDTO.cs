using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class RecommendationDTO
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public string Invitation { get; set; }
        public bool IsUsed { get; set; }
        public int? IdTraining { get; set; }
    }
}
