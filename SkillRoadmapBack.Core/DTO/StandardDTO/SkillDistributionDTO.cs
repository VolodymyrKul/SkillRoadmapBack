using System;
using System.Collections.Generic;
using System.Text;

namespace SkillRoadmapBack.Core.DTO.StandardDTO
{
    public class SkillDistributionDTO
    {
        public int Id { get; set; }
        public int IdParentSkill { get; set; }
        public int IdChildSkill { get; set; }
    }
}
