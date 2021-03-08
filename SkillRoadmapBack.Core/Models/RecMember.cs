using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class RecMember : IBaseEntity
    {
        public int Id { get; set; }
        public int? IdRecommend { get; set; }
        public Recommendation IdRecommendNavigation { get; set; }
        public int? IdTraining { get; set; }
        public Training IdTrainingNavigation { get; set; }
    }
}
