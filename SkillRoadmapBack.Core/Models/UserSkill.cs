using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class UserSkill : IBaseEntity
    {
        public UserSkill()
        {
            Comments = new HashSet<Comment>();
            ParentSkillDistributions = new HashSet<SkillDistribution>();
            ChildSkillDistributions = new HashSet<SkillDistribution>();
            Notifications = new HashSet<Notification>();
        }
        public int Id { get; set; }
        public string Skillname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? IdCategory { get; set; }
        public int SkillLevel { get; set; }
        public int? IdEmployee { get; set; }
        public Employee IdEmployeeNavigation { get; set; }
        public Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<SkillDistribution> ParentSkillDistributions { get; set; }
        public virtual ICollection<SkillDistribution> ChildSkillDistributions { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
