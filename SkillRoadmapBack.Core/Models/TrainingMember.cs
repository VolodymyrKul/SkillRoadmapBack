using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class TrainingMember : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdTraining { get; set; }
        public Training IdTrainingNavigation { get; set; }
        public int? IdMember { get; set; }
        public Employee IdMemberNavigation { get; set; }
        public bool IsEnded { get; set; }
    }
}
