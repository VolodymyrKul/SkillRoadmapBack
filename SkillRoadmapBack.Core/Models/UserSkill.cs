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
            Notifications = new HashSet<Notification>();
            SkillUnits = new HashSet<SkillUnit>();
            Certificates = new HashSet<Certificate>();
            SkillMetrics = new HashSet<SkillMetric>();
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
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<SkillUnit> SkillUnits { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<SkillMetric> SkillMetrics { get; set; }
    }
}
