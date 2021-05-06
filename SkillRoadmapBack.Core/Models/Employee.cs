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
            Certificates = new HashSet<Certificate>();
            TrainingMembers = new HashSet<TrainingMember>();
            Recommendations = new HashSet<Recommendation>();
            Statisticses = new HashSet<Statistics>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string DevLevel { get; set; }
        public double Experience { get; set; }
        public int? IdMentor { get; set; }
        public Employer IdEmployerNavigation { get; set; }
        public int? IdCompany { get; set; }
        public Company IdCompanyNavigation { get; set; }
        public virtual ICollection<UserSkill> UserSkills { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<TrainingMember> TrainingMembers { get; set; }
        public virtual ICollection<Recommendation> Recommendations { get; set; }
        public virtual ICollection<Statistics> Statisticses { get; set; } 
        public virtual ICollection<Comparation> Comparations { get; set; }
    }
}
