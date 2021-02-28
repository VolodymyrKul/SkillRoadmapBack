using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class EmployeeInfoDTO
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string DevLevel { get; set; }
        public double Experience { get; set; }
        public string MentorEmail { get; set; }
    }
}
