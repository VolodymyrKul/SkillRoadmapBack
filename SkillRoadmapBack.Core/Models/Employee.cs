using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Employee : IBaseEntity
    {
        public Employee()
        {
            Notifications = new HashSet<Notification>();
            UserSkills = new HashSet<UserSkill>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DevLevel { get; set; }
        public double Experience { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
