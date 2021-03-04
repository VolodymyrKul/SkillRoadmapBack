using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class SetUserSkillDTO
    {
        public string Skillname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CategoryName { get; set; }
        public int SkillLevel { get; set; }
        public string EmployeeEmail { get; set; }
    }
}
