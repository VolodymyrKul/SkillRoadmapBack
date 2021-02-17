using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class UserSkillDTO
    {
        public int Id { get; set; }
        public string Skillname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdCategory { get; set; }
        public int SkillLevel { get; set; }
        public int IdEmployee { get; set; }
    }
}
