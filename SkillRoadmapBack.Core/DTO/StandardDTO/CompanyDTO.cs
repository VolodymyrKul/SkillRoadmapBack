using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class CompanyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeesCount { get; set; }
        public string Description { get; set; }
        public string Specialization { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
    }
}
