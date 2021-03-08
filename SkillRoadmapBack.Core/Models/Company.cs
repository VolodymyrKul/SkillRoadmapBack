using SkillRoadmapBack.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Company : IBaseEntity
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
            Employers = new HashSet<Employer>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeesCount { get; set; }
        public string Description { get; set; }
        public string Specialization { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
    }
}
