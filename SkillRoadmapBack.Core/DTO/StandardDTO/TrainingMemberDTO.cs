using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class TrainingMemberDTO
    {
        public int Id { get; set; }
        public int? IdTraining { get; set; }
        public int? IdMember { get; set; }
        public bool IsEnded { get; set; }
    }
}
