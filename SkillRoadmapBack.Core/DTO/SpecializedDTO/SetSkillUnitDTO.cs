using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.SpecializedDTO
{
    public class SetSkillUnitDTO
    {
        public string Unitname { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitLevel { get; set; }
        public string UserSkillName { get; set; }
    }
}
