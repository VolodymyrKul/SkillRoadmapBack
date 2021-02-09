using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class EmployeeDTO : EmployerDTO
    {
        public string DevLevel { get; set; }
        public double Experience { get; set; }
    }
}
