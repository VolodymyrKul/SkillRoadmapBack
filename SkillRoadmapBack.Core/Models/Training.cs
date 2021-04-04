using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Training : IBaseEntity
    {
        public Training()
        {
            TrainingMembers = new HashSet<TrainingMember>();
            //RecMembers = new HashSet<RecMember>();
        }
        public int Id { get; set; }
        public string TrainingTitle { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TrainingLevel { get; set; }
        public double Payment { get; set; }
        public int? IdCoach { get; set; }
        public Employer IdCoachNavigation { get; set; }
        public int? IdCategory { get; set; }
        public Category IdCategoryNavigation { get; set; }
        public virtual ICollection<TrainingMember> TrainingMembers { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
    }
}
