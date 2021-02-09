using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Employee : Employer
    {
        public Employee()
        {
            Notifications = new HashSet<Notification>();
            UserSkills = new HashSet<UserSkill>();
        }
        public string DevLevel { get; set; }
        public double Experience { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
    }
}
