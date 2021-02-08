using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.Models
{
    public class Employee : Employer
    {
        public string DevLevel { get; set; }
        public double Experience { get; set; }
    }
}
