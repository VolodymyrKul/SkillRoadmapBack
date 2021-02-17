using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class SkillUnitDTO
    {
        public int Id { get; set; }
        public string Unitname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitLevel { get; set; }
        public int IdUserSkill { get; set; }
    }
}
