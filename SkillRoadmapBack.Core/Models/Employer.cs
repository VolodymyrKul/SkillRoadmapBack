using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Employer : IBaseEntity
    {
        public Employer()
        {
            Comments = new HashSet<Comment>();
            Notifications = new HashSet<Notification>();
            Employees = new HashSet<Employee>();
            Certificates = new HashSet<Certificate>();
            Trainings = new HashSet<Training>();
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int? IdCompany { get; set; }
        public Company IdCompanyNavigation { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Certificate> Certificates { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
