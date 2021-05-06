using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class ComparationDTO
    {
        public int Id { get; set; }
        public int IdRequirement { get; set; }
        public string ReqTitle { get; set; }
        public int IdEmployee { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeNSN { get; set; }
        public bool IsMeetCriteria { get; set; }
    }
}
